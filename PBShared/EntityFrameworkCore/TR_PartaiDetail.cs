using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.EntityFrameworkCore
{
    [Table("TR_PartaiDetail")]
    public class TR_PartaiDetail
    {
        [Key]
        public int partaiId { get; set; }
        [Key]
        public int timId { get; set; }
        public int score { get; set; }
        public Boolean pemenang { get; set; }
        public string auditUN { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
