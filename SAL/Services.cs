﻿using CurrieTechnologies.Razor.SweetAlert2;
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
        Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosong(string kategori, string StatusPenghunian);
        Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWA_Kosong(); Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWK_Kosong();
        Task<int> CountJumlahTWKDisewa(); Task<int> CountJumlahTWADisewa();
        Task<int> CountJumlahTWKBukanDisewa(); Task<int> CountJumlahTWABukanDisewa();
        Task<IEnumerable<tblInfoTanahWakaf>> CariRekodHartaTanahWakafByDaerahSahaja(string daerah);
        Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWA_Sewa(); Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWK_Sewa();
        Task<IEnumerable<DashboardInfo>> GetKegunaanByStatusPenghunian(); Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodHartaTanahByNoLotSahaja(string nolot);
        Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodBasedOnLotdanDaerahSahaja(string nolot, string daerah);

        Task<IEnumerable<ViewButiranStaf>> GetInfoDataFromEHR(string nostaf);
        Task<IEnumerable<DashboardInfo>> GetInfoTanahKosongByDaerahSahaja(); Task<bool> CheckExistingUserId(string nokp, string email);
        Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWA_BukanSewaan(); Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWK_BukanSewaan();
        Task<bool> UpdateExistingPassword(tblInfoUsereTakaf data);
        Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahKosongbyKategoriDetails(string statuspenghunian);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahKosongByKategoriWakaf(string statuspenghunian);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfoGroupByDaerahDanJenisWakaf(string daerah);
        Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahBukanKosongbyKategoriDetails(string statuspenghunian);
        Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahBukanKosongByKategoriWakaf(string statuspenghunian);
        Task<IEnumerable<NilaiRMTanahWakaf>> GetNilaiRMTanahWakaf();
        Task<IEnumerable<OutputCarian>> GetInfoDetailsBothTables(string nolot, string daerah);
        Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosongForAKForPublic();
        Task<bool> UpdateStatusPenyewaanTanahWakaf(tblInfoTanahWakaf data);
        Task<bool> InsertNewPenyewaanRekod(tblInfoPermohonanPenyewaan data);
        Task<IEnumerable<tblInfoPermohonanPenyewaan>> GetRecordPermohonanPenyewaanBaruMohon();
        Task<IEnumerable<DashboardInfo>> GetDashboardLaporanPecahanRekodByTanahBangunan();

        Task<IEnumerable<tblInfoPermohonanPenyewaan>> GetRecordPermohonanPenyewaanMelaluiNOKP(string nokp);
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

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosong(string kategori, string statuspenghunian)
        {
            return await _master.GetDetailsTanahWakafKosong(kategori, statuspenghunian);
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWA_Kosong()
        {
            var ada = await _master.GetDetailsTanahWakafKosong("AM","Kosong");
            if (ada != null)
            {
                for (int i = 0; i < ada.Count(); i++)
                {
                    ada.ElementAt(i).Id = i + 1;
                }
            }
            return ada ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWK_Kosong()
        {
            var ada1 = await _master.GetDetailsTanahWakafKosong("KHAS","Kosong");
            if (ada1 != null)
            {
                for (int i = 0; i < ada1.Count(); i++)
                {
                    ada1.ElementAt(i).Id = i + 1;
                }
            }
            return ada1 ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWK_Sewa()
        {
            var ada1 = await _master.GetDetailsTanahWakafBukanKosong("Khas", "Kosong");
            if (ada1 != null)
            {
                for (int i = 0; i < ada1.Count(); i++)
                {
                    ada1.ElementAt(i).Id = i + 1;
                }
            }
            return ada1 ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }     
        public async Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWA_Sewa()
        {
            var ada1 = await _master.GetDetailsTanahWakafBukanKosong("Am", "Kosong");
            if (ada1 != null)
            {
                for (int i = 0; i < ada1.Count(); i++)
                {
                    ada1.ElementAt(i).Id = i + 1;
                }
            }
            return ada1 ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWA_BukanSewaan()
        {
            var ada1 = await _master.GetDetailsTanahWakafKosong("AM", "Bukan Sewaan");
            if (ada1 != null)
            {
                for (int i = 0; i < ada1.Count(); i++)
                {
                    ada1.ElementAt(i).Id = i + 1;
                }
            }
            return ada1 ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetRekodTWK_BukanSewaan()
        {
            var ada1 = await _master.GetDetailsTanahWakafKosong("Khas", "Bukan Sewaan");
            if (ada1 != null)
            {
                for (int i = 0; i < ada1.Count(); i++)
                {
                    ada1.ElementAt(i).Id = i + 1;
                }
            }
            return ada1 ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }



        public async Task<int> CountJumlahTWADisewa()
        {
            return await _master.CountJumlahTWADisewa();
        }

        public async Task<int> CountJumlahTWKDisewa()
        {
            return await _master.CountJumlahTWKDisewa();
        }

        public async Task<int> CountJumlahTWKBukanDisewa()
        {
            return await _master.CountJumlahTWKBukanDisewa();
        }
        public async Task<int> CountJumlahTWABukanDisewa()
        {
            return await _master.CountJumlahTWABukanDisewa();
        }

        public async Task<IEnumerable<DashboardInfo>> GetKegunaanByStatusPenghunian()
        {
            return await _master.GetKegunaanByStatusPenghunian();
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> CariRekodHartaTanahWakafByDaerahSahaja(string daerah)
        {
            var bil =  await _master.CariRekodHartaTanahWakafByDaerahSahaja(daerah);
            if (bil != null)
            {
                for (int i = 0; i < bil.Count(); i++)
                {
                    bil.ElementAt(i).Id = i + 1;
                }
            }
            return bil ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }
        public async Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodHartaTanahByNoLotSahaja(string nolot)
        {
            return await _master.CarianRekodHartaTanahByNoLotSahaja(nolot); 
        }

        public async Task<IEnumerable<tblLegasiWakafMAINS>> CarianRekodBasedOnLotdanDaerahSahaja(string nolot, string daerah)
        {
            return await _master.CarianRekodBasedOnLotdanDaerahSahaja(nolot, daerah);
        }

        public async Task<IEnumerable<ViewButiranStaf>> GetInfoDataFromEHR(string nostaf)
        {
            return await _master.GetInfoDataFromEHR(nostaf); 
        }

        public async Task<IEnumerable<DashboardInfo>> GetInfoTanahKosongByDaerahSahaja()
        {
            return await _master.GetInfoTanahKosongByDaerahSahaja();
        }

        public async Task<bool> CheckExistingUserId(string nokp, string email)
        {
            return await _master.CheckExistingUserId(nokp, email);
        }

        public async Task<bool> UpdateExistingPassword(tblInfoUsereTakaf data)
        {
            return await _master.UpdateExistingPassword(data);
        }

        public async Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahKosongbyKategoriDetails(string statuspenghunian)
        {
            return await _master.GetPecahanRecordTanahKosongbyKategoriDetails(statuspenghunian);
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahKosongByKategoriWakaf(string statuspenghunian)
        {
            return await _master.GetDashboardInfoPecahanTanahKosongByKategoriWakaf(statuspenghunian);   
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfoGroupByDaerahDanJenisWakaf(string daerah)
        {
            return await _master.GetDashboardInfoGroupByDaerahDanJenisWakaf(daerah);
        }

        public async Task<IEnumerable<PecahanRekodTanah>> GetPecahanRecordTanahBukanKosongbyKategoriDetails(string statuspenghunian)
        {
            return await _master.GetPecahanRecordTanahBukanKosongbyKategoriDetails(statuspenghunian);
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardInfoPecahanTanahBukanKosongByKategoriWakaf(string statuspenghunian)
        {
            return await _master.GetDashboardInfoPecahanTanahBukanKosongByKategoriWakaf(statuspenghunian);
        }

        public async Task<IEnumerable<NilaiRMTanahWakaf>> GetNilaiRMTanahWakaf()
        {
            return await _master.GetNilaiRMTanahWakaf();
        }

        public async Task<IEnumerable<OutputCarian>> GetInfoDetailsBothTables(string nolot, string daerah)
        {
            return await _master.GetInfoDetailsBothTables(nolot, daerah);
        }

        public async Task<IEnumerable<tblInfoTanahWakaf>> GetDetailsTanahWakafKosongForAKForPublic()
        {
            var bil =  await _master.GetDetailsTanahWakafKosongForAKForPublic();
            if (bil != null)
            {
                for (int i = 0; i < bil.Count(); i++)
                {
                    bil.ElementAt(i).Id = i + 1;
                }
            }
            return bil ?? Enumerable.Empty<tblInfoTanahWakaf>();
        }

        public async Task<bool> InsertNewPenyewaanRekod(tblInfoPermohonanPenyewaan data)
        {
            return await _master.InsertNewPenyewaanRekod(data);
        }

        public async Task<bool> UpdateStatusPenyewaanTanahWakaf(tblInfoTanahWakaf data)
        {
            return await _master.UpdateStatusPenyewaanTanahWakaf(data);
        }


        public async Task<IEnumerable<tblInfoPermohonanPenyewaan>> GetRecordPermohonanPenyewaanBaruMohon()
        {
            var bil =  await _master.GetRecordPermohonanPenyewaanBaruMohon();
            if (bil != null)
            {
                for (int i = 0; i < bil.Count(); i++)
                {
                    bil.ElementAt(i).Bil = i + 1;
                }
            }
            return bil ?? Enumerable.Empty<tblInfoPermohonanPenyewaan>();
        }

        public async Task<IEnumerable<DashboardInfo>> GetDashboardLaporanPecahanRekodByTanahBangunan()
        {
            var bil = await _master.GetDashboardLaporanPecahanRekodByTanahBangunan();
            if (bil != null)
            {
                for (int i = 0; i < bil.Count(); i++)
                {
                    bil.ElementAt(i).Bil = i + 1;
                }
            }
            return bil ?? Enumerable.Empty<DashboardInfo>();
        }

        public async Task<IEnumerable<tblInfoPermohonanPenyewaan>> GetRecordPermohonanPenyewaanMelaluiNOKP(string nokp)
        {
            var bil = await _master.GetRecordPermohonanPenyewaanMelaluiNOKP(nokp);
            if (bil != null)
            {
                for (int i = 0; i < bil.Count(); i++)
                {
                    bil.ElementAt(i).Bil = i + 1;
                }
            }
            return bil ?? Enumerable.Empty<tblInfoPermohonanPenyewaan>();
        }



    }

}
