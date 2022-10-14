using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(a => a.DireccionHogar, d =>
            {
                d.Property(p => p.Calle).HasColumnName("Calle");
                d.Property(p => p.Provincia).HasColumnName("Provincia");
                d.Property(p => p.Pais).HasColumnName("Pais");
            });
        }
    }
}
