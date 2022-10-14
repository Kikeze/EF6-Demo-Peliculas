using Microsoft.EntityFrameworkCore;

namespace DemoEF6Peliculas.Entidades.Seeding
{
    public static class SeedingPersonaMensaje
    {
        public static void Seed(ModelBuilder builder)
        {
            var Gelipe = new Persona() { Id = 1, Nombre = "Gelipe" };
            var Lencha = new Persona() { Id = 2, Nombre = "Lencha" };

            var Mensaje1 = new Mensaje() { Id = 1, Contenido = "Hola Lencha!", EmisorId = Gelipe.Id, ReceptorId = Lencha.Id };
            var Mensaje2 = new Mensaje() { Id = 2, Contenido = "Pinchi Gelipe! Me espantaste!", EmisorId = Lencha.Id, ReceptorId = Gelipe.Id };
            var Mensaje3 = new Mensaje() { Id = 3, Contenido = "Pues estas bien mensa!", EmisorId = Gelipe.Id, ReceptorId = Lencha.Id };
            var Mensaje4 = new Mensaje() { Id = 4, Contenido = "Vete a la verde!", EmisorId = Lencha.Id, ReceptorId = Gelipe.Id };

            builder.Entity<Persona>().HasData(Gelipe, Lencha);
            builder.Entity<Mensaje>().HasData(Mensaje1, Mensaje2, Mensaje3, Mensaje4);
        }
    }
}
