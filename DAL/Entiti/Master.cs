using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entiti
{
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
        public DateTime? TarikhMula { get; set; } = null;
        public string TarikhTamat { get; set; } = string.Empty;
        public double? SewaBulanan { get; set; } = null;
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
        public byte? JumlahBelanja { get; set; } = null;
    }

}
