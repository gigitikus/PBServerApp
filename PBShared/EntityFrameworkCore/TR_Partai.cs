using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.EntityFrameworkCore
{ 
    [Table("TR_Partai")]
    public class TR_Partai
    {
        [Key]
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
        public string auditUN { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}
