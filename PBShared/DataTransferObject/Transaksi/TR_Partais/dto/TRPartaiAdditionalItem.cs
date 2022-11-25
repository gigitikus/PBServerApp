using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.DataTransferObject.Transaksi.TR_Partais.dto
{
    public class TRPartaiAdditionalItem
    {
        public int partaiId { get; set; }
        public int itemId { get; set; }
        public string namaItem { get; set; }
        public decimal hargaItem { get; set; }
        public int qty { get; set; }
        public decimal totalHarga { get; set; }
    }
}
