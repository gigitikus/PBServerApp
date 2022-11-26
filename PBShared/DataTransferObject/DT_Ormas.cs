using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.DataTransferObject
{
    public class DT_Ormas
    {
         public string kodeOrmas { get; set; }
         public string namaOrmas { get; set; }
         public string alamat { get; set; }
         public string namaPimpinan { get; set; }
         public string nomorTerdaftar { get; set; }
         public string bidangKegiatan { get; set; }
         public string keterangan { get; set; }
         public string? suku { get; set; }
         public bool berbadanHukum { get; set; }
         public byte[] logoOrmas { get; set; }
         public string nomorTelp { get; set; }
         public byte[]? photoPimpinan { get; set; }
         public bool aktif { get; set; }
         public string inputUN { get; set; }
         public DateTime inputTime { get; set; }
         public string? modifiedUN { get; set; }
         public DateTime? modifiedTime { get; set; }
    }
}
