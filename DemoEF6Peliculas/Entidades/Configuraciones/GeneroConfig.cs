using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasQueryFilter(p => !p.EstaBorrado);

            builder.HasIndex(p => p.Nombre)
                .IsUnique()
                .HasFilter("EstaBorrado = 'false'");

            builder.Property<DateTime>("FechaCreacion")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnType("datetime");

        }
    }
}
