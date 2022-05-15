using Microsoft.EntityFrameworkCore;
using Model;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Table1>(entity =>
            {
                entity.ToTable("Table1");
                entity.Property(x => x.Tbl1Prp2).HasMaxLength(255);
            });
            modelBuilder.Entity<Table2>(entity =>
            {
                entity.ToTable("Table2");
                entity.Property(x => x.Tbl2Prp2).HasMaxLength(255);
                entity.HasOne(x => x.Table1).WithMany(x => x.Table2Properties);
            });
            modelBuilder.Entity<Table3>(entity =>
            {
                entity.ToTable("Table3");
                entity.Property(x => x.Tbl3Prp2).HasMaxLength(255);
                entity.HasOne(x => x.Table2).WithMany(x => x.Table3Properties);
            });
        }
    }
}
