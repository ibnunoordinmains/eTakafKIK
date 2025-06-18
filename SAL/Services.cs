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
        Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerahNoLotNoGeran(string daerah, string jenisnohakmilik, string nolot);
        Task<IEnumerable<myCarian4>> CarianDataTWA(); Task<IEnumerable<myCarian4>> CarianDataTWAByDaerah(string daerah);
        Task<bool> InsertNewRecordForRegistration(tblInfoUsereTakaf tblInfoUsereTakaf);
        Task<bool> CheckDuplicateRecordPengguna(string noKP, string namaPemohon, string noHP, string email);
        Task<string> HandleUserRegistration(tblInfoUsereTakaf info);
        Task<IEnumerable<tblInfoUsereTakaf>> GetLoginInfo(string NoKp);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfo(); Task<IEnumerable<DashboardInfo>> GetKegunaanTanah();
        Task<int> CountJumlahTWAKosongBothKategori(); Task<int> CountJumlahTWKKosongBothKategori();
        Task<IEnumerable<tblLegasiWakafMAINS>> GetDetailsTanahWakafKosong(string kategori);
        Task<IEnumerable<tblLegasiWakafMAINS>> GetRekodTWA_Kosong(); Task<IEnumerable<tblLegasiWakafMAINS>> GetRekodTWK_Kosong();
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

        public async Task<IEnumerable<tblLegasiWakaf>> GetMaklumatLegasiByDaerahNoLotNoGeran(string daerah, string jenisnohakmilik, string nolot)
        {
            return await _master.GetMaklumatLegasiByDaerahNoLotNoGeran(daerah, jenisnohakmilik, nolot);
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
            catch (System.Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        public async Task<IEnumerable<myCarian4>> CarianDataTWA()
        {
            return await _master.CarianDataTWA();
        }

        public async Task<IEnumerable<myCarian4>> CarianDataTWAByDaerah(string daerah)
        {
            return await _master.CarianDataTWAByDaerah(daerah);
        }

        public async Task<bool> InsertNewRecordForRegistration(tblInfoUsereTakaf tblInfoUsereTakaf)
        {
            return await _master.InsertNewRecordForRegistration(tblInfoUsereTakaf);
        }

        public async Task<bool> CheckDuplicateRecordPengguna(string noKP, string namaPemohon, string noHP, string email)
        {
            return await _master.CheckDuplicateRecordPengguna(noKP, namaPemohon, noHP, email);
        }

        public async Task<string> HandleUserRegistration(tblInfoUsereTakaf info)
        {
            bool isDuplicate = await CheckDuplicateRecordPengguna(info.NoKP, info.NamaPemohon, info.NoHP, info.Email);

            if (isDuplicate)
                return "Data Pengguna Telah WUJUD.";

            bool isInserted = await InsertNewRecordForRegistration(info);

            return isInserted ? "Maklumat Pengguna Berjaya Disimpan." : "Maklumat Pengguna TIDAK Berjaya Disimpan.";
        }

        public async Task<IEnumerable<tblInfoUsereTakaf>> GetLoginInfo(string NoKp)
        {
            return await _master.GetLoginInfo(NoKp);
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfo()
        {
            return await _master.GetDashboardInfo();
        }

        public async Task<IEnumerable<DashboardInfo>> GetKegunaanTanah()
        {
            return await _master.GetKegunaanTanah();
        }

        public async Task<int> CountJumlahTWAKosongBothKategori()
        {
            return await _master.CountJumlahTWAKosongBothKategori();
        }

        public async Task<int> CountJumlahTWKKosongBothKategori()
        {
            return await _master.CountJumlahTWKKosongBothKategori();
        }

        public async Task<IEnumerable<tblLegasiWakafMAINS>> GetDetailsTanahWakafKosong(string kategori)
        {
            return await _master.GetDetailsTanahWakafKosong(kategori);
        }


        public async Task<IEnumerable<tblLegasiWakafMAINS>> GetRekodTWA_Kosong()
        {
            var ada = await _master.GetDetailsTanahWakafKosong("Wakaf (am)");
            if (ada != null)
            {
                for (int i = 0; i < ada.Count(); i++)
                {
                    ada.ElementAt(i).Bil = i + 1;
                }
            }
            return ada;
        }

        public async Task<IEnumerable<tblLegasiWakafMAINS>> GetRekodTWK_Kosong()
        {
            var ada1 = await _master.GetDetailsTanahWakafKosong("Wakaf (Khas)");
            if (ada1 != null)
            {
                for (int i = 0; i < ada1.Count(); i++)
                {
                    ada1.ElementAt(i).Bil = i + 1;
                }
            }
            return ada1;
        }


    }

}
