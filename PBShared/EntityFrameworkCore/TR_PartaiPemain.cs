using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.EntityFrameworkCore
{
    [Table("TR_PartaiPemain")]
    public class TR_PartaiPemain
    {
        [Key]
        public int partaiId { get; set; }
        [Key]
        public int timId { get; set; }
        [Key]
        public string namaPemain { get; set; }
        public int pemainKe { get; set; }
        public decimal totalBayar { get; set; }
        public decimal sisaTotalBayar { get; set; }
        public Boolean terbayarPenuh { get; set; }
        public string auditUN { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
