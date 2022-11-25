using Microsoft.EntityFrameworkCore;
using PBShared.DataTransferObject.Transaksi;
using PBShared.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.DBContexts
{
    public class PBManageServiceContext : DbContext
    {
        public virtual DbSet<TR_Partai> TR_Partai { get; set; }
        public virtual DbSet<TR_PartaiDetail> TR_PartaiDetail { get; set; }
        public virtual DbSet<TR_PartaiAdditionalItem> TR_PartaiAdditionalItem { get; set; }
        public virtual DbSet<TR_PartaiPemain> TR_PartaiPemain { get; set; }
        public PBManageServiceContext(DbContextOptions<PBManageServiceContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TR_Partai>()
                .HasKey(n => n.partaiId);

            modelBuilder.Entity<TR_PartaiDetail>()
                .HasKey(n => new { n.partaiId, n.timId });

            modelBuilder.Entity<TR_PartaiAdditionalItem>()
                .HasKey(n => new { n.partaiId, n.itemId });

            modelBuilder.Entity<TR_PartaiPemain>()
                .HasKey(n => new { n.partaiId, n.timId, n.namaPemain });
        }
    }
}
