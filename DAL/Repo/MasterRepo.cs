using DAL.Conn;
using DAL.Entiti;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosong(string kategori, string StatusPenghunian);
        Task<int> CountJumlahTWADisewa(); Task<int> CountJumlahTWKDisewa();
        Task<int> CountJumlahTWKBukanDisewa(); Task<int> CountJumlahTWABukanDisewa();
        Task<IEnumerable<DashboardInfo>> GetKegunaanByStatusPenghunian();
        Task<IEnumerable<tblInfoTanahWakaf>> CariRekodHartaTanahWakafByDaerahSahaja(string daerah);
        Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodHartaTanahByNoLotSahaja(string nolot);
        Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodBasedOnLotdanDaerahSahaja(string nolot, string daerah);
        Task<IEnumerable<ViewButiranStaf>> GetInfoDataFromEHR(string nostaf);
        Task<IEnumerable<DashboardInfo>> GetInfoTanahKosongByDaerahSahaja(); Task<bool> CheckExistingUserId(string nokp, string email);
        Task<bool> UpdateExistingPassword(tblInfoUsereTakaf data);
        Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahKosongbyKategoriDetails(string statuspenghunian);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahKosongByKategoriWakaf(string statuspenghunian);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfoGroupByDaerahDanJenisWakaf(string daerah);
        Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahBukanKosongbyKategoriDetails(string statuspenghunian);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahBukanKosongByKategoriWakaf(string statuspenghunian);
        Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafBukanKosong(string kategori, string StatusPenghunian);
        Task<IEnumerable<NilaiRMTanahWakaf>> GetNilaiRMTanahWakaf();
        Task<IEnumerable<OutputCarian>> GetInfoDetailsBothTables(string nolot, string daerah);

        Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosongForAKForPublic();

    }
    public class MasterRepo(ServerProd serverProd, ServerEHR serverEhr) : IMasterRepo
    {
        private readonly ServerProd _serverProd = serverProd;
        private readonly ServerEHR _serverEhr = serverEhr;
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
                return await _serverProd.Connections.QueryAsync<tblLegasiWakaf>(sql, new { daerah = daerah, jenisnohakmilik = jenisnohakmilik, nolot = nolot });
            }
            catch (SqlException err)
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
                return await _serverProd.Connections.QueryAsync<myCarian4>(sql);
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
                return await _serverProd.Connections.QueryAsync<myCarian4>(sql, new { daerah = daerah });
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
            catch (System.Exception err)
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
            string sql = @"SELECT daerah, count(daerah) as JumlahTanah FROM [tblinfotanahwakaf] group by daerah order by daerah";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql);
        }

        public async Task<IEnumerable<DashboardInfo>> GetKegunaanTanah()
        {
            string sql = @"SELECT jenishartanah as keterangan, count(JenisHartanah) as jumlahtanah FROM tblLegasiWakafMAINS group by JenisHartanah order by JenisHartanah";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql);
        }

        public async Task<int> CountJumlahTWAKosongBothKategori()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblinfotanahwakaf where jenis_wakaf='AM' AND kod in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<int> CountJumlahTWKKosongBothKategori()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblinfotanahwakaf where jenis_wakaf='KHAS' and kod in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<int> CountJumlahTWADisewa()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblinfotanahwakaf where jenis_wakaf='am' and kod not in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<int> CountJumlahTWKDisewa()
        {
            string sql = @"SELECT count(*) as jumlah FROM tblinfotanahwakaf where jenis_wakaf='khas' and kod not in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')";
            return await _serverProd.Connections.ExecuteScalarAsync<int>(sql);
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosong(string kategori, string StatusPenghunian)
        {
            try
            {
                string sql = @"select * from tblinfotanahwakaf
                                where jenis_wakaf = @kategori and  
                                  kod in ('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')";
                string pattern = $"%{StatusPenghunian}%";
               
                return await _serverProd.Connections.QueryAsync<tblInfoTanahWakaf>(sql, new { kategori = kategori, pattern });
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }


        public async Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosongForAKForPublic()
        {
            try
            {
                string sql = @"select * from tblinfotanahwakaf
                                where (jenis_wakaf = 'AM' or jenis_wakaf='KHAS') and  
                                  kod in ('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')";
                //string pattern = $"%{StatusPenghunian}%";

                return await _serverProd.Connections.QueryAsync<tblInfoTanahWakaf>(sql);
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafBukanKosong(string kategori, string StatusPenghunian)
        {
            try
            {
                string sql = @"select * from tblinfotanahwakaf
                                where jenis_wakaf = @kategori and  
                                  kod not in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')";
                string pattern = $"%{StatusPenghunian}%";

                return await _serverProd.Connections.QueryAsync<tblInfoTanahWakaf>(sql, new { kategori = kategori, pattern });
            }
            catch (System.Exception err)
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

        public async Task<IEnumerable<tblInfoTanahWakaf>> CariRekodHartaTanahWakafByDaerahSahaja(string daerah)
        {
            string sql = @"SELECT * FROM tblinfotanahwakaf where Daerah = @Daerah";
            return await _serverProd.Connections.QueryAsync<tblInfoTanahWakaf>(sql, new { daerah = daerah });
        }

        public async Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodHartaTanahByNoLotSahaja(string nolot)
        {
            string sql = @"select * from tblinfotanahwakaf where no_lot = @nolot";
            return await _serverProd.Connections.QueryAsync<tblLegasiWakafMAINS>(sql, new { nolot = nolot });
        }

        public async Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodBasedOnLotdanDaerahSahaja(string nolot, string daerah)
        {
            string sql = @"select * from tblLegasiWakafMAINS where nolot = @nolot and daerah = @daerah";
            return await _serverProd.Connections.QueryAsync<tblLegasiWakafMAINS>(sql, new { nolot = nolot, daerah = daerah });
        }

        public async Task<IEnumerable<ViewButiranStaf>> GetInfoDataFromEHR(string nostaf)
        {
            string sql = @" select * from view_butiran_staf where nostaf = @nostaf";
            return await _serverEhr.Connections.QueryAsync<ViewButiranStaf>(sql, new { nostaf = nostaf });
        }


        public async Task<IEnumerable<DashboardInfo>> GetInfoTanahKosongByDaerahSahaja()
        {
            string sql = @"select count(daerah) as jumlahtanah,daerah  from tblinfotanahwakaf
                            where kod in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')
                            group by daerah order by daerah";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql);
        }


        public async Task<bool> CheckExistingUserId(string nokp, string email)
        {
            string sql = @"SELECT COUNT(*) FROM tblInfoUsereTakaf WHERE nokp = @nokp AND email = @email";
            int count = await _serverProd.Connections.QuerySingleAsync<int>(sql, new { nokp, email });
            return count > 0;
        }

        public async Task<bool> UpdateExistingPassword(tblInfoUsereTakaf data)
        {
            string sql = @"update tblInfoUsereTakaf set katalaluan = @katalaluan where nokp = @nokp AND email = @email";
            var xx =  await _serverProd.Connections.ExecuteAsync(sql, new {katalaluan = data.Katalaluan, nokp = data.NoKP, email = data.Email });
            return xx > 0;
        }

        public async Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahKosongbyKategoriDetails(string statuspenghunian)
        {
            string sql = @"select count(jenis_wakaf) as jumlah,jenis_wakaf as JenisWakaf, kegunaan_kategori as kategori from tblinfotanahwakaf
                            where kod in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')
                            group by jenis_wakaf,kegunaan_kategori";
            return await _serverProd.Connections.QueryAsync<PecahanRekodTanah>(sql ,new { statuspenghunian = statuspenghunian });
        }

        public async Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahBukanKosongbyKategoriDetails(string statuspenghunian)
        {
            string sql = @"select count(jenis_wakaf) as jumlah,jenis_wakaf as JenisWakaf, kegunaan_kategori as kategori from tblinfotanahwakaf
                            where kod not in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')
                            group by jenis_wakaf,kegunaan_kategori";
            return await _serverProd.Connections.QueryAsync<PecahanRekodTanah>(sql, new { statuspenghunian = statuspenghunian });
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahKosongByKategoriWakaf(string statuspenghunian)
        {
            string sql = @"SELECT COUNT(jenis_wakaf) AS jumlahtanah,
                                   jenis_wakaf + '-' + kegunaan_kategori AS keterangan
                            FROM tblinfotanahwakaf
                            WHERE kod in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')
                            GROUP BY jenis_wakaf, kegunaan_kategori
                            ORDER BY jenis_wakaf";

            string pattern = $"%{statuspenghunian}%";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql, new { pattern });
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahBukanKosongByKategoriWakaf(string statuspenghunian)
        {
            string sql = @"select count(jenis_wakaf) as jumlahtanah,jenis_wakaf as JenisWakaf, kegunaan_kategori as keterangan from tblinfotanahwakaf
                            where kod not in('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS')
                            group by jenis_wakaf,kegunaan_kategori";

           string pattern = $"%{statuspenghunian}%";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql, new { pattern });
        }

     

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfoGroupByDaerahDanJenisWakaf(string daerah)
        {
            string sql = @"SELECT daerah, Jenis_Wakaf AS Keterangan, COUNT(*) AS JumlahTanah
                            FROM tblinfotanahwakaf where daerah=@daerah GROUP BY 
                            jenis_wakaf,daerah  ORDER BY jenis_wakaf";
            return await _serverProd.Connections.QueryAsync<DashboardInfo>(sql,new { daerah = daerah });
        }

        public async Task<IEnumerable<NilaiRMTanahWakaf>> GetNilaiRMTanahWakaf()
        {
            string sql = @"
                        SELECT
                            SUM(NILAIAN_TANAH_RM) AS JumlahKeseluruhan,
                            SUM(CASE 
                                    WHEN kod NOT IN ('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS') 
                                    THEN NILAIAN_TANAH_RM ELSE 0
                                END) AS JumlahBukanKosong,
                            SUM(CASE 
                                    WHEN kod IN ('BRWK','IPIK','IPITK','LKR','STK','TK','TKGETAH','TKSAWIT','TS') 
                                    THEN NILAIAN_TANAH_RM ELSE 0
                                END) AS JumlahKosong
                        FROM tblinfotanahwakaf";
            return await _serverProd.Connections.QueryAsync<NilaiRMTanahWakaf>(sql);
        }


        public async Task<IEnumerable<OutputCarian>> GetInfoDetailsBothTables(string nolot, string daerah)
        {
            string sql = @"SELECT * FROM tblLegasiWakafMAINS a
                                FULL OUTER JOIN TblInfoTanahWakaf b
                                    ON a.NoLot = b.NO_LOT AND a.Daerah = b.DAERAH
                                WHERE (a.NoLot = @nolot AND a.Daerah = @daerah)
                                    OR (b.NO_LOT = @nolot AND b.DAERAH = @daerah)";
            return await _serverProd.Connections.QueryAsync<OutputCarian>(sql, new { nolot = nolot, daerah = daerah }); 
        }


    }
}
