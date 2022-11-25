using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.DataTransferObject.Transaksi.TR_Partais.dto
{
    public class TRPartaiPemain
    {
        public int partaiId { get; set; }
        public int timId { get; set; }
        public string namaPemain { get; set; }
        public int pemainKe { get; set; }
        public decimal totalBayar { get; set; }
        public decimal sisaTotalBayar { get; set; }
        public Boolean terbayarPenuh { get; set; }
    }
}
