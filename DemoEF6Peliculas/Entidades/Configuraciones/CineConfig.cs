using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class CineConfig : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(p => p.Oferta)
                .WithOne()
                .HasForeignKey<CineOferta>(o => o.CineId);

            builder.HasMany(c => c.SalasCine)
                .WithOne(c => c.Cine)
                .HasForeignKey(s => s.CineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CineDetalle)
                .WithOne(d => d.Cine)
                .HasForeignKey<CineDetalle>(d => d.Id);

            builder.OwnsOne(c => c.Direccion, d =>
            {
                d.Property(d => d.Calle).HasColumnName("Calle");
                d.Property(d => d.Provincia).HasColumnName("Provincia");
                d.Property(d => d.Pais).HasColumnName("Pais");
            });

        }
    }
}
