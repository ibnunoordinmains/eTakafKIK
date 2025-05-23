using DAL.Conn;
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

        public async Task<int> GetCounterNumberTakaf(string jenisCarian)
        {
            try
            {
                string sql = @"select nombor from tblNoTakaf where JenisCarian=@JenisCarian";
                return await _serverProd.Connections.QuerySingleAsync<int>(sql, new { JenisCarian = jenisCarian });
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



    }
}
