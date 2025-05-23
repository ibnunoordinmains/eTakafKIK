using CurrieTechnologies.Razor.SweetAlert2;
using DAL.Entiti;
using DAL.Repo;
using Microsoft.JSInterop;


namespace SAL
{
    public interface IServices
    {
        Task<IEnumerable<InfoDaerah>> GetInfoDaerahOnly();
        Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiRekod(string tahun, string kategori, string daerah);
        Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerah(string daerah);
        Task ShowSweetAlertAsync(string title, string text, SweetAlertIcon? icon = null, bool showCancelButton = false, string confirmButtonText = "Ok");
        Task<int> GetCounterNumberTakaf(string jenisCarian);
        Task<bool> UpdateCounterNumber(string jenisCarian, int bil);
        Task<int> UpdateRunningNumber(string carian);
    }
    public class Services(IMasterRepo masterRepo, SweetAlertService swal) : IServices
    {
        private readonly IMasterRepo _master = masterRepo;
        private readonly SweetAlertService _swal = swal;

        public async Task<IEnumerable<InfoDaerah>> GetInfoDaerahOnly()
        {
            return await _master.GetInfoDaerahOnly();
        }

        public async Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiRekod(string tahun, string kategori, string daerah)
        {
            return await _master.GetMaklumatLegasiRekod(tahun, kategori, daerah);
        }

        public async Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerah(string daerah)
        {
            return await _master.GetMaklumatLegasiByDaerah(daerah);
        }

        public async Task ShowSweetAlertAsync(
            string title,
            string text,
            SweetAlertIcon? icon = null, // Changed to nullable type
            bool showCancelButton = false,
            string confirmButtonText = "Ok")
        {
            var options = new SweetAlertOptions
            {
                Title = title,
                Text = text,
                Icon = icon ?? SweetAlertIcon.Info, // Use null-coalescing operator to set default value
                ShowCancelButton = showCancelButton,
                ConfirmButtonText = confirmButtonText
            };

            await _swal.FireAsync(options);
        }

        public async Task<int> GetCounterNumberTakaf(string jenisCarian)
        {
            return await _master.GetCounterNumberTakaf(jenisCarian);
        }

        public async Task<bool> UpdateCounterNumber(string jenisCarian, int bil)
        {
            return await _master.UpdateCounterNumber(jenisCarian, bil);
        }


        public async Task<int> UpdateRunningNumber(string carian)
        {
            try
            {
                var bil = await GetCounterNumberTakaf(carian);
                bil++;
                await UpdateCounterNumber(carian, bil);
                return bil;
            }
            catch(System.Exception err)
            {
                throw new Exception(err.Message);   
            }
           
        }




    }
    
}
