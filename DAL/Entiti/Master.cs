using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entiti
{
    public class LoginModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class ModelSearch
    {
        public string NoLotSearch { get; set; } = string.Empty;
    }
    public class InfoDaerah
    {
        public int Id { get; set; }
        public string DaerahDW { get; set; } = string.Empty;
    }

    public class tblLegasiWakaf
    {
        public int Id { get; set; }
        public int Idx { get; set; }
        public int? Bil { get; set; }
        public string NoFail { get; set; } = string.Empty;
        public string Daerah { get; set; } = string.Empty;
        public string NoDaftar { get; set; } = string.Empty;
        public string MaklumatHartanah { get; set; } = string.Empty;
        public string NoAkaunCukaiTaksiran { get; set; } = string.Empty;
        public string NoAkaunCukaiTanah { get; set; } = string.Empty;
        public string MaklumatHartanah1 { get; set; } = string.Empty;
        public string Pewakaf { get; set; } = string.Empty;
        public string JenisNoHakMilik { get; set; } = string.Empty;
        public string NoLot { get; set; } = string.Empty;
        public string MukimPekanBandar { get; set; } = string.Empty;
        public string KegunaanKategori { get; set; } = string.Empty;
        public string KeluasanTanah { get; set; } = string.Empty;
        public string KeluasanTanahDiWakaf { get; set; } = string.Empty;
        public decimal? NilaianTanah { get; set; }
        public DateTime? TahunWakaf { get; set; }
        public string Catatan { get; set; } = string.Empty;
        public string CukaiTaksiran { get; set; } = string.Empty;
    }

    public class ReportGroupLegasi
    {
        public int Id { get; set; }
        public string Daerah { get; set; } = string.Empty;
        public string NoFail { get; set; } = string.Empty;
        public int JumlahRekod { get; set; }
        public decimal Luas { get; set; }
    }

    public class tblNoTakaf
    {
        public int Id { get; set; } // Auto-incremented Identity column

        public string JenisCarian { get; set; } = string.Empty;

        public int? Nombor { get; set; } // Nullable integer, aligns with table definition
    }

    public class myCarian4
    {
        public int Id { get; set; }
        public string Jumlah { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public string Daerah { get; set; } = string.Empty;
    }

    public class tblInfoUsereTakaf
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string NoKP { get; set; } = string.Empty;

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "Katalaluan Tidak Memenuhi Spesifikasi")]
        public string Katalaluan { get; set; } = string.Empty;

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "Katalaluan Tidak Memenuhi Spesifikasi")]
        public string Katalaluan1 { get; set; } = string.Empty;

        public string NamaPemohon { get; set; } = string.Empty;

        public string NoHP { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int? Status { get; set; }

        public bool? IsActive { get; set; }

    }

    public class DashboardInfo
    {
        public string Daerah { get; set; } = string.Empty;
        public string JenisHartanah { get; set; } = string.Empty;
        public int JumlahTanah { get; set; }
        public string Keterangan { get; set; } = string.Empty;
    }

    public class tblLegasiWakafMAINS
    {
        public int Bil { get; set; } = 0;
        public string AlamatPremis { get; set; } = string.Empty;
        public string NamaPenyewaPenghuni { get; set; } = string.Empty;
        public string LuasRuangLantaisqft { get; set; } = string.Empty;
        public string NamaHartanah { get; set; } = string.Empty;
        public double? LuasTanahm2 { get; set; } = null;
        public double? LuasTanahsqft { get; set; } = null;
        public double? LuasTanahHaDalamGeran { get; set; } = null;
        public double? LuasTanahekar { get; set; } = null;
        public double? LuastanahdiwakafkanHa { get; set; } = null;
        public double? Luastanahdiwakafkanekar { get; set; } = null;
        public string JenisHartanah { get; set; } = string.Empty;
        public string NoLot { get; set; } = string.Empty;
        public string NoGeran { get; set; } = string.Empty;
        public string Mukim { get; set; } = string.Empty;
        public string Daerah { get; set; } = string.Empty;
        public string PeganganTanah { get; set; } = string.Empty;
        public string TempohPajakan { get; set; } = string.Empty;
        public string SyaratNyataTanah { get; set; } = string.Empty;
        public string KategoriSumberAmWakaf { get; set; } = string.Empty;
        public string StatusPenghunian { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public string Tempoh { get; set; } = string.Empty;
        public DateTime? TarikhMula { get; set; } 
        public DateTime? TarikhTamat { get; set; } 
        public decimal? SewaBulanan { get; set; } = null;
        public decimal? SewaTahunan { get; set; } = null;
        public double? Semasa { get; set; } = null;
        public double? Terkumpul { get; set; } = null;
        public double? Semasa2 { get; set; } = null;
        public double? Terkumpul2 { get; set; } = null;
        public string Catatan { get; set; } = string.Empty;
        public double? CukaiTanah { get; set; } = null;
        public double? CukaiPintuSetahun { get; set; } = null;
        public string Insurans { get; set; } = string.Empty;
        public string Security { get; set; } = string.Empty;
        public string Pembersihan { get; set; } = string.Empty;
        public string Parking { get; set; } = string.Empty;
        public string Elektrik { get; set; } = string.Empty;
        public string Air { get; set; } = string.Empty;
        public string Akuarium { get; set; } = string.Empty;
        public string ServisCaj { get; set; } = string.Empty;
        public string SinkingFund { get; set; } = string.Empty;
        public string PenyelenggaraanBulanan { get; set; } = string.Empty;
        public string KerjakerjaPembaikan2025 { get; set; } = string.Empty;
        public string BajetPembaikan2025 { get; set; } = string.Empty;
        public string StatusSemasaHartanah { get; set; } = string.Empty;
        public string Nota { get; set; } = string.Empty;
        public int? JumlahBelanja { get; set; } = null;
        public string NoDaftar { get; set; } = string.Empty;
    }

    public class tblInfoTanahWakaf
    {
        public int Id { get; set; }
        public int BIL { get; set; } = 0;
        public string NO_DAFTAR { get; set; } = string.Empty;
        public string PEWAKAF { get; set; } = string.Empty;
        public string JENIS_WAKAF { get; set; } = string.Empty;
        public string DAERAH { get; set; } = string.Empty;
        public string JENIS_NO_HAKMILIK { get; set; } = string.Empty;
        public string NO_LOT { get; set; } = string.Empty;
        public string MUKIM_PEKAN_BANDAR { get; set; } = string.Empty;
        public string KEGUNAAN_KATEGORI { get; set; } = string.Empty;
        public double KELUASAN_TANAH_ha { get; set; } = 0.0;
        public double KELUASAN_YANG_DIWAKAFKAN_ha { get; set; } = 0.0;
        public double NILAIAN_TANAH_RM { get; set; } = 0.0;
        public DateTime? TAHUN_WAKAF { get; set; } = null;
        public string KOD { get; set; } = string.Empty;
        public string CATATAN { get; set; } = string.Empty;
        public int Status { get; set; } = 0;
    }

    public class ViewButiranStaf
    {
        public string NoStaf { get; set; } = string.Empty;
        public string NoStafBaca { get; set; } = string.Empty;
        public string NoStafPenuh { get; set; } = string.Empty;
        public string Nama { get; set; } = string.Empty;
        public string Ic { get; set; } = string.Empty;
        public int? JabatanId { get; set; }
        public string Jabatan { get; set; } = string.Empty;
        public int? BahagianId { get; set; }
        public string Bahagian { get; set; } = string.Empty;
        public int? UnitId { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int PenempatanId { get; set; }
        public string Penempatan { get; set; } = string.Empty;
        public int? JawatanId { get; set; }
        public string Jawatan { get; set; } = string.Empty;
        public int? GredId { get; set; }
        public string Gred { get; set; } = string.Empty;
        public string Emel { get; set; } = string.Empty;
        public string NoTelefon { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }



    public class PecahanRekodTanah
    {
        public string JenisWakaf { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public int Jumlah { get; set; }
    }


    public class NilaiRMTanahWakaf
    {
        public double JumlahKeseluruhan { get; set; }
        public double JumlahBukanKosong { get; set; }
        public double JumlahKosong { get; set; }
    }


    public class OutputCarian
    {
        // Fields from tblLegasiWakafMAINS
        public byte Bil { get; set; }
        public string Alamat_Premis { get; set; } = string.Empty;
        public string NamaPenyewaPenghuni { get; set; } = string.Empty;
        public string LuasRuangLantaisqft { get; set; } = string.Empty;
        public string NamaHartanah { get; set; } = string.Empty;
        public double? LuasTanahm2 { get; set; }
        public double? LuasTanahsqft { get; set; }
        public double? LuasTanahHaDalamGeran { get; set; }
        public double? LuasTanahekar { get; set; }
        public double? LuastanahdiwakafkanHa { get; set; }
        public double? Luastanahdiwakafkanekar { get; set; }
        public string JenisHartanah { get; set; } = string.Empty;
        public string NoLot { get; set; } = string.Empty;
        public string NoGeran { get; set; } = string.Empty;
        public string Mukim { get; set; } = string.Empty;
        public string Daerah { get; set; } = string.Empty;
        public string PeganganTanah { get; set; } = string.Empty;
        public string TempohPajakan { get; set; } = string.Empty;
        public string SyaratNyataTanah { get; set; } = string.Empty;
        public string KategoriSumberAmWakaf { get; set; } = string.Empty;
        public string StatusPenghunian { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public string Tempoh { get; set; } = string.Empty;
        public DateTime? TarikhMula { get; set; }
        public DateTime? TarikhTamat { get; set; }
        public double? SewaBulanan { get; set; }
        public decimal? SewaTahunan { get; set; }
        public double? Semasa { get; set; }
        public double? Terkumpul { get; set; }
        public double? Semasa2 { get; set; }
        public double? Terkumpul2 { get; set; }
        public string Catatan { get; set; } = string.Empty;
        public double? CukaiTanah { get; set; }
        public double? CukaiPintuSetahun { get; set; }
        public string Insurans { get; set; } = string.Empty;
        public string Security { get; set; } = string.Empty;
        public string Pembersihan { get; set; } = string.Empty;
        public string Parking { get; set; } = string.Empty;
        public string Elektrik { get; set; } = string.Empty;
        public string Air { get; set; } = string.Empty;
        public string Akuarium { get; set; } = string.Empty;
        public string ServisCaj { get; set; } = string.Empty;
        public string SinkingFund { get; set; } = string.Empty;
        public string PenyelenggaraanBulanan { get; set; } = string.Empty;
        public string KerjakerjaPembaikan2025 { get; set; } = string.Empty;
        public string BajetPembaikan2025 { get; set; } = string.Empty;
        public string StatusSemasaHartanah { get; set; } = string.Empty;
        public string Nota { get; set; } = string.Empty;
        public byte? JumlahBelanja { get; set; }
        public string NoDaftar { get; set; } = string.Empty;

        // Fields from TblInfoTanahWakaf
        public byte BIL { get; set; }
        public string NO_DAFTAR { get; set; } = string.Empty;
        public string PEWAKAF { get; set; } = string.Empty;
        public string JENIS_WAKAF { get; set; } = string.Empty;
        public string DAERAH { get; set; } = string.Empty;
        public string JENIS_NO_HAKMILIK { get; set; } = string.Empty;
        public string NO_LOT { get; set; } = string.Empty;
        public string MUKIM_PEKAN_BANDAR { get; set; } = string.Empty;
        public string KEGUNAAN_KATEGORI { get; set; } = string.Empty;
        public double KELUASAN_TANAH_ha { get; set; }
        public double KELUASAN_YANG_DIWAKAFKAN_ha { get; set; }
        public double? NILAIAN_TANAH_RM { get; set; }
        public DateTime? TAHUN_WAKAF { get; set; }
        public string KOD { get; set; } = string.Empty;
        public string CATATAN { get; set; } = string.Empty;
    }


    public class tblInfoPermohonanPenyewaan
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string NoKPPemohon { get; set; } = string.Empty;
        public string NamaPemohon { get; set; } = string.Empty;
        public string Daerah { get; set; } = string.Empty;
        public string Mukim { get; set; } = string.Empty;
        public string NoLot { get; set; } = string.Empty;
        public string NoGeran { get; set; } = string.Empty;
        public int? Status { get; set; }
    }



}
