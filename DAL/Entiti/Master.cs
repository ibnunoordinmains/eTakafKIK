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
        public int JumlahTanah { get; set; }
    }
}
