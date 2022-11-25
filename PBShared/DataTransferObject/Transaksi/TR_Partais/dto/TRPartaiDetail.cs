using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.DataTransferObject.Transaksi.TR_Partais.dto
{
    public class TRPartaiDetail
    {
        public int partaiId { get; set; }
        public int timId { get; set; }
        public int score { get; set; }
        public Boolean pemenang { get; set; }
    }
}
