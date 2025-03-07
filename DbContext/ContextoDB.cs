using Microsoft.EntityFrameworkCore;
using SistemaCotizaciones.Models;

namespace SistemaCotizaciones.Context
{
    public class ContextoDB : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<TipoSeguro> TipoSeguros { get; set; }

        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoSeguro>(entity =>
            {
                entity.ToTable("TipoSeguro");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Identidad)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(c => c.FechaNacimiento)
                    .IsRequired();
                entity.Property(c => c.TipoCliente)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(c => c.Telefono)
                    .HasMaxLength(20);
                entity.Property(c => c.Correo)
                    .HasMaxLength(100);
                entity.HasCheckConstraint("CHK_TipoCliente", "TipoCliente IN ('Natural', 'Juridico')");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.ToTable("Cotizacion");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.NumeroCotizacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode();
                entity.Property(c => c.FechaCotizacion)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()");
                entity.Property(c => c.Moneda)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(c => c.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(c => c.SumaAsegurada)
                    .IsRequired()
                    .HasColumnType("DECIMAL(18,2)");
                entity.Property(c => c.Tasa)
                    .IsRequired()
                    .HasColumnType("DECIMAL(5,2)");
                entity.Property(c => c.PrimaNeta)
                    .IsRequired()
                    .HasColumnType("DECIMAL(18,2)");

                entity.HasOne(c => c.TipoSeguro)
                    .WithMany(t => t.Cotizaciones)
                    .HasForeignKey(c => c.TipoSeguroId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(c => c.Cliente)
                    .WithMany(cli => cli.Cotizaciones)
                    .HasForeignKey(c => c.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });
        }

    }
}
