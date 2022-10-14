using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF6Peliculas.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(p => new { p.PeliculaId, p.ActorId });
            builder.Property(p => p.Personaje)
                .HasMaxLength(150);

            builder.HasOne(p => p.Actor)
                .WithMany(a => a.PeliculasActores)
                .HasForeignKey(p => p.ActorId);

            builder.HasOne(p => p.Pelicula)
                .WithMany(p => p.PeliculasActores)
                .HasForeignKey(p => p.PeliculaId);
        }
    }
}
