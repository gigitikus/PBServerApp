using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.DataTransferObject.Transaksi.TR_Partais.dto
{
    public class TRPartai
    {
        public int partaiId { get; set; }
        public string partaiCode { get; set; }
        public int partaiKe { get; set; }
        public DateTime waktuMulai { get; set; }
        public DateTime waktuSelesai { get; set; }
        public Boolean kalahBayarCock { get; set; }
        public int jumlahCock { get; set; }
        public decimal biayaPerPartai { get; set; }
        public decimal sisaBiayaPerPartai { get; set; }
        public Boolean terbayarPenuh { get; set; }
        public int TotalCount { get; set; }
    }
}
