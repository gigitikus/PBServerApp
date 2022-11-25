using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.EntityFrameworkCore
{
    [Table("TR_PartaiAdditionalItem")]
    public class TR_PartaiAdditionalItem
    {
        [Key]
        public int partaiId { get; set; }
        [Key]
        public int itemId { get; set; }
        public string namaItem { get; set; }
        public decimal hargaItem { get; set; }
        public int qty { get; set; }
        public decimal totalHarga { get; set; }
        public string auditUN { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
