﻿using DAL.Conn;
using DAL.Entiti;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface IMasterRepo
    {
        Task<IEnumerable<InfoDaerah>> GetInfoDaerahOnly();
        Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiRekod(string tahun, string kategori, string daerah);
        Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerah(string daerah);
        Task<int> GetCounterNumberTakaf(string jenisCarian);
        Task<bool> UpdateCounterNumber(string jenisCarian, int bil);
        Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerahNoLotNoGeran(string daerah, string jenisnohakmilik, string nolot);
        Task<IEnumerable<myCarian4>> CarianDataTWA();
        Task<IEnumerable<myCarian4>> CarianDataTWAByDaerah(string daerah);
        Task<bool> InsertNewRecordForRegistration(tblInfoUsereTakaf tblInfoUsereTakaf);
        Task<bool> CheckDuplicateRecordPengguna(string noKP, string namaPemohon, string noHP, string email);
        Task<IEnumerable<tblInfoUsereTakaf>> GetLoginInfo(string NoKp);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfo(); Task<IEnumerable<DashboardInfo>> GetKegunaanTanah();
        Task<int> CountJumlahTWAKosongBothKategori(); Task<int> CountJumlahTWKKosongBothKategori();
        Task<IEnumerable<tblLegasiWakafMAINS>> GetDetailsTanahWakafKosong(string kategori, string StatusPenghunian);
        Task<int> CountJumlahTWADisewa(); Task<int> CountJumlahTWKDisewa();
        Task<int> CountJumlahTWKBukanDisewa(); Task<int> CountJumlahTWABukanDisewa();
        Task<IEnumerable<DashboardInfo>> GetKegunaanByStatusPenghunian();
        Task<IEnumerable<tblLegasiWakafMAINS>> CariRekodHartaTanahWakafByDaerahSahaja(string daerah);
        Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodHartaTanahByNoLotSahaja(string nolot);
    }
    public class MasterRepo(ServerProd serverProd ) : IMasterRepo
    {
        private readonly ServerProd _serverProd = serverProd;
        public async Task<IEnumerable<InfoDaerah>> GetInfoDaerahOnly()
        {
           try
            {
                string sql = @"select distinct(Daerah) as DaerahDW from tblDaerahInfo order by daerah";
                return await _serverProd.Connections.QueryAsync<InfoDaerah>(sql);
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }

        }

        public async Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiRekod(string tahun, string kategori, string daerah)
        {
            try
            {
                string sql = @"select * from tblLegasiWakaf where year(TahunWakaf) =@TahunWakaf
                                and NoFail=@NoFail and Daerah=@Daerah";
                return await _serverProd.Connections.QueryAsync<tblLegasiWakaf>(sql, new { TahunWakaf = tahun, NoFail = kategori, Daerah = daerah });
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerah(string daerah)
        {
            try
            {
                string sql = @"select * from tblLegasiWakaf where Daerah=@Daerah";
                return await _serverProd.Connections.QueryAsync<tblLegasiWakaf>(sql, new { Daerah = daerah });
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }


        public async Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerahNoLotNoGeran(string daerah, string jenisnohakmilik, string nolot)
        {
            try
            {
                string sql = @"SELECT * FROM [tblLegasiWakaf] where daerah = @daerah and nolot = @nolot and JENISNOHAKMILIK = @jenisnohakmilik";
                return await _serverProd.Connections.QueryAsync<tblLegasiWakaf>(sql, new {daerah = daerah, jenisnohakmilik = jenisnohakmilik, nolot = nolot });
            }
            catch(SqlException err)
            {
                throw new Exception(err.Message);
            }
        }



        public async Task<int> GetCounterNumberTakaf(string jenisCarian)
        {
            try
            {
                string sql = @"select nombor from tblNoTakaf where JenisCarian=@JenisCarian";
                // return await _serverProd.Connections.QuerySingleAsync<int>(sql, new { JenisCarian = jenisCarian });
                var result = await _serverProd.Connections.QuerySingleOrDefaultAsync<int>(sql, new { JenisCarian = jenisCarian });
                return result; 
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<bool> UpdateCounterNumber(string jenisCarian, int bil)
        {
            try
            {
                string sql = @"update tblNoTakaf set Nombor=@Nombor where JenisCarian=@JenisCarian";
                var result = await _serverProd.Connections.ExecuteAsync(sql, new { Nombor = bil, JenisCarian = jenisCarian });
                return result > 0;
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<IEnumerable<myCarian4>> CarianDataTWA()
        {
            try
            {
                string sql = @" select daerah,nofail as kategori, count(nofail) as jumlah  from tblLegasiWakaf
                               where nofail='TWA'
                               group by nofail,DAERAH order by DAERAH asc";
                return  await _serverProd.Connections.QueryAsync<myCarian4>(sql);
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<IEnumerable<myCarian4>> CarianDataTWAByDaerah(string daerah)
        {
            try
            {
                string sql = @" select daerah,nofail as kategori, count(nofail) as jumlah  from tblLegasiWakaf
                               where nofail='TWA' and daerah = @daerah
                               group by nofail,DAERAH order by DAERAH asc";
                return await _serverProd.Connections.QueryAsync<myCarian4>(sql, new { daerah = daerah});
            }
            catch (SqlException err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<bool> InsertNewRecordForRegistration(tblInfoUsereTakaf tblInfoUsereTakaf)
        {
            try
            {
                string sql = @"INSERT INTO tblInfoUsereTakaf (CreatedDate, NoKP, Katalaluan, NamaPemohon, NoHP, Email, Status, IsActive) VALUES (@CreatedDate, @NoKP, @Katalaluan, @NamaPemohon, @NoHP, @Email, @Status, @IsActive);";
                var res = await _serverProd.Connections.ExecuteAsync(sql, tblInfoUsereTakaf);
                return res > 0;

            }
            catch (SqlException err)
            {
                return false;
                throw new Exception(err.Message);
            }
        }


        public async Task<bool> CheckDuplicateRecordPengguna(string noKP, string namaPemohon, string noHP, string email)
        {
            try
            {
                string sql = @"SELECT COUNT(*) FROM tblInfoUsereTakaf 
                   WHERE NoKP = @NoKP AND NamaPemohon = @NamaPemohon 
                   AND NoHP = @NoHP AND Email = @Email";

                int count = await _serverProd.Connections.ExecuteScalarAsync<int>(sql, new { NoKP = noKP, NamaPemohon = namaPemohon, NoHP = noHP, Email = email });

                return count > 0;
            }
            catch(System.Exception err)
            {
                return false;
                throw new Exception(err.Message);
            }
        }

        public async Task<IEnumerable<tblInfoUsereTakaf>> GetLoginInfo(string NoKp)
        {
            string sql = @"select top 1 * from tblInfoUsereTakaf where nokp = @NoKp and isactive = 1";
            return await _serverProd.Connections.QueryAsync<tblInfoUsereTakaf>(sql, new { NoKp = NoKp });
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfo()
        {
            string sql = @"SELECT daerah, count(daerah) as JumlahTanah FROM [tblLegasiWakafMAINS] group by daerah order by daerah";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql);
        }

        public async Task<IEnumerable<DashboardInfo>> GetKegunaanTanah()
        {
            string sql = @"SELECT jenishartanah as keterangan, count(JenisHartanah) as jumlahtanah FROM tblLegasiWakafMAINS group by JenisHartanah order by JenisHartanah";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql);
        }

        public async Task<int> CountJumlahTWAKosongBothKategori()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblLegasiWakafMAINS where KategoriSumberAmWakaf='Wakaf (am)' and StatusPenghunian='Kosong'";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<int> CountJumlahTWKKosongBothKategori()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblLegasiWakafMAINS where KategoriSumberAmWakaf='Wakaf (Khas)' and StatusPenghunian='Kosong'";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<int> CountJumlahTWADisewa()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblLegasiWakafMAINS where KategoriSumberAmWakaf='Wakaf (am)' and StatusPenghunian='Disewa'";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<int> CountJumlahTWKDisewa()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblLegasiWakafMAINS where KategoriSumberAmWakaf='Wakaf (Khas)' and StatusPenghunian='Disewa'";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<IEnumerable<tblLegasiWakafMAINS>> GetDetailsTanahWakafKosong(string kategori, string StatusPenghunian)
        {
            try
            {
                string sql = @"SELECT *  FROM tblLegasiWakafMAINS where KategoriSumberAmWakaf = @kategori and StatusPenghunian = @StatusPenghunian";
                return await _serverProd.Connections.QueryAsync<tblLegasiWakafMAINS>(sql, new { kategori = kategori, StatusPenghunian = StatusPenghunian});
            }
            catch(System.Exception err)
            {
                throw new Exception(err.Message);
            }

        }


        public async Task<int> CountJumlahTWKBukanDisewa()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblLegasiWakafMAINS where KategoriSumberAmWakaf='Wakaf (Khas)' and StatusPenghunian='Bukan Sewaan'";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<int> CountJumlahTWABukanDisewa()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblLegasiWakafMAINS where KategoriSumberAmWakaf='Wakaf (am)' and StatusPenghunian='Bukan Sewaan'";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }


        public async Task<IEnumerable<DashboardInfo>> GetKegunaanByStatusPenghunian()
        {
            string sql = @"SELECT statuspenghunian as keterangan, count(statuspenghunian) as jumlahtanah FROM tblLegasiWakafMAINS group by statuspenghunian order by statuspenghunian";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql);
        }

        public async Task<IEnumerable<tblLegasiWakafMAINS>> CariRekodHartaTanahWakafByDaerahSahaja(string daerah)
        {
            string sql = @"SELECT * FROM tblLegasiWakafMAINS where Daerah = @Daerah";
            return await _serverProd.Connections.QueryAsync<tblLegasiWakafMAINS>(sql, new { daerah = daerah });
        }


        public async Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodHartaTanahByNoLotSahaja(string nolot)
        {
            string sql = @"select * from tblLegasiWakafMAINS where nolot = @nolot";
            return await _serverProd.Connections.QueryAsync<tblLegasiWakafMAINS>(sql, new { nolot = nolot });
        }


    }
}
