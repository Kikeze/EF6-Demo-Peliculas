using System.Reflection;

using Microsoft.EntityFrameworkCore;

using DemoEF6Peliculas.Entidades;
using DemoEF6Peliculas.Entidades.Configuraciones;
using DemoEF6Peliculas.Entidades.Seeding;
using DemoEF6Peliculas.Entidades.SinLlaves;

namespace DemoEF6Peliculas
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            // Do nothing
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateTime>().HaveColumnType("datetime");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new GeneroConfig());
            //builder.ApplyConfiguration(new ActorConfig());
            //builder.ApplyConfiguration(new CineConfig());
            //builder.ApplyConfiguration(new PeliculaConfig());
            //builder.ApplyConfiguration(new CineOfertaConfig());
            //builder.ApplyConfiguration(new SalaCineConfig());
            //builder.ApplyConfiguration(new PeliculaActorConfig());

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedingModuloConsulta.Seed(builder);
            SeedingPersonaMensaje.Seed(builder);

            builder.Entity<CineSinUbicacion>()
                .HasNoKey()
                .ToSqlQuery("SELECT id, nombre FROM Cines")
                .ToView(null);

            builder.Entity<PeliculaConConteo>()
                .HasNoKey()
                .ToView("PeliculaConteo");

            foreach(var tipo in builder.Model.GetEntityTypes())
            {
                foreach(var prop in tipo.GetProperties())
                {
                    if(prop.ClrType == typeof(string) && prop.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
                    {
                        prop.SetIsUnicode(false);
                        prop.SetMaxLength(1024);
                    }
                }
            }

            builder.Entity<PeliculaAlquilable>().ToTable("PeliculasAlquilables");
            builder.Entity<Juguete>().ToTable("Juguetes");

            var pelicula1 = new PeliculaAlquilable()
            {
                Id = 1,
                Nombre = "Spider-Man",
                PeliculaId = 1,
                Precio = 5.99M
            };
            var juguete1 = new Juguete()
            {
                Id = 2,
                Disponible = true,
                esRopa = true,
                Nombre = "Playera",
                Peso = 1,
                Volumen = 1,
                Precio = 11
            };

            builder.Entity<PeliculaAlquilable>().HasData(pelicula1);
            builder.Entity<Juguete>().HasData(juguete1);
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaCine> SalasCine { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CineSinUbicacion> CinesSinUbicacion { get; set; }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }

        public DbSet<CineDetalle> CinesDetalle { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Producto> Productos { get; set; }


    }
}
