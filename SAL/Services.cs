using DAL.Entiti;
using DAL.Repo;

namespace SAL
{
    public interface IServices
    {
        Task<IEnumerable<InfoDaerah>> GetInfoDaerahOnly();
        Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiRekod(string tahun, string kategori, string daerah);
    }
    public class Services(IMasterRepo masterRepo) :IServices
    {
        private readonly IMasterRepo _master = masterRepo;


        public async Task<IEnumerable<InfoDaerah>> GetInfoDaerahOnly()
        {
            return await _master.GetInfoDaerahOnly();
        }

        public async Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiRekod(string tahun, string kategori, string daerah)
        {
            return await _master.GetMaklumatLegasiRekod(tahun, kategori, daerah);
        }
    }
    
}
