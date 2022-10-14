using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Titulo)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasMany(p => p.Generos)
                .WithMany(g => g.Peliculas)
                .UsingEntity(j => j.ToTable("GenerosPeliculas"));

        }
    }
}
