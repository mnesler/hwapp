using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hwapp.Models
{
    public partial class RegisterContext : DbContext
    {
        public RegisterContext()
        {
        }

        public RegisterContext(DbContextOptions<RegisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Registrations> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:hwsql01.database.windows.net,1433;Initial Catalog=Register;Persist Security Info=False;User ID=mnesler;Password=<your sql server password>;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registrations>(entity =>
            {
                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);
            });
        }
    }
}
