using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using System.Reflection.Emit;

namespace DemoEF6Peliculas.Entidades.Seeding
{
    public static class SeedingModuloConsulta
    {
        public static void Seed(ModelBuilder builder)
        {
            var acción = new Genero { Id = 1, Nombre = "Acción" };
            var animación = new Genero { Id = 2, Nombre = "Animación" };
            var comedia = new Genero { Id = 3, Nombre = "Comedia" };
            var cienciaFicción = new Genero { Id = 4, Nombre = "Ciencia ficción" };
            var drama = new Genero { Id = 5, Nombre = "Drama" };

            builder.Entity<Genero>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { Id = 1, Nombre = "Tom Holland", Nacimiento = new DateTime(1996, 6, 1), Biografia = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { Id = 2, Nombre = "Samuel L. Jackson", Nacimiento = new DateTime(1948, 12, 21), Biografia = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { Id = 3, Nombre = "Robert Downey Jr.", Nacimiento = new DateTime(1965, 4, 4), Biografia = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { Id = 4, Nombre = "Chris Evans", Nacimiento = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Nombre = "Dwayne Johnson", Nacimiento = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Nombre = "Auli'i Cravalho", Nacimiento = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Nombre = "Scarlett Johansson", Nacimiento = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Nombre = "Keanu Reeves", Nacimiento = new DateTime(1964, 9, 2) };

            builder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cine() { Id = 1, Nombre = "Agora Mall", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cine() { Id = 2, Nombre = "Sambil", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cine() { Id = 3, Nombre = "Megacentro", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cine() { Id = 4, Nombre = "Acropolis", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var agoraCineOferta = new CineOferta { Id = 1, CineId = agora.Id, Inicio = DateTime.Today, Final = DateTime.Today.AddDays(7), Descuento = 10 };

            var SalaCine2DAgora = new SalaCine()
            {
                Id = 1,
                CineId = agora.Id,
                Precio = 220,
                Tipo = TipoSalaCine.DosDimensiones
            };
            var SalaCine3DAgora = new SalaCine()
            {
                Id = 2,
                CineId = agora.Id,
                Precio = 320,
                Tipo = TipoSalaCine.TresDimensiones
            };

            var SalaCine2DSambil = new SalaCine()
            {
                Id = 3,
                CineId = sambil.Id,
                Precio = 200,
                Tipo = TipoSalaCine.DosDimensiones
            };
            var SalaCine3DSambil = new SalaCine()
            {
                Id = 4,
                CineId = sambil.Id,
                Precio = 290,
                Tipo = TipoSalaCine.TresDimensiones
            };


            var SalaCine2DMegacentro = new SalaCine()
            {
                Id = 5,
                CineId = megacentro.Id,
                Precio = 250,
                Tipo = TipoSalaCine.DosDimensiones
            };
            var SalaCine3DMegacentro = new SalaCine()
            {
                Id = 6,
                CineId = megacentro.Id,
                Precio = 330,
                Tipo = TipoSalaCine.TresDimensiones
            };
            var SalaCineCXCMegacentro = new SalaCine()
            {
                Id = 7,
                CineId = megacentro.Id,
                Precio = 450,
                Tipo = TipoSalaCine.VIP
            };

            var SalaCine2DAcropolis = new SalaCine()
            {
                Id = 8,
                CineId = acropolis.Id,
                Precio = 250,
                Tipo = TipoSalaCine.DosDimensiones
            };

            var acropolisCineOferta = new CineOferta { Id = 2, CineId = acropolis.Id, Inicio = DateTime.Today, Final = DateTime.Today.AddDays(5), Descuento = 15 };

            builder.Entity<Cine>().HasData(acropolis, sambil, megacentro, agora);
            builder.Entity<CineOferta>().HasData(acropolisCineOferta, agoraCineOferta);
            builder.Entity<SalaCine>().HasData(SalaCine2DMegacentro, SalaCine3DMegacentro, SalaCineCXCMegacentro, SalaCine2DAcropolis, SalaCine2DAgora, SalaCine3DAgora, SalaCine2DSambil, SalaCine3DSambil);


            var avengers = new Pelicula()
            {
                Id = 1,
                Titulo = "Avengers",
                EnCartelera = false,
                Estreno = new DateTime(2012, 4, 11),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var entidadGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosId";
            var peliculaIdPropiedad = "PeliculasId";

            var entidadSalaCinePelicula = "PeliculaSalaCine";
            var SalaCineIdPropiedad = "SalasCineId";

            builder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = avengers.Id },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = avengers.Id }
            );

            var coco = new Pelicula()
            {
                Id = 2,
                Titulo = "Coco",
                EnCartelera = false,
                Estreno = new DateTime(2017, 11, 22),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            builder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = animación.Id, [peliculaIdPropiedad] = coco.Id }
           );

            var noWayHome = new Pelicula()
            {
                Id = 3,
                Titulo = "Spider-Man: No way home",
                EnCartelera = false,
                Estreno = new DateTime(2021, 12, 17),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            builder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Id, [peliculaIdPropiedad] = noWayHome.Id }
           );

            var farFromHome = new Pelicula()
            {
                Id = 4,
                Titulo = "Spider-Man: Far From Home",
                EnCartelera = false,
                Estreno = new DateTime(2019, 7, 2),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            builder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Id, [peliculaIdPropiedad] = farFromHome.Id }
           );

            // Para matrix pongo la fecha en el futuro

            var theMatrixResurrections = new Pelicula()
            {
                Id = 5,
                Titulo = "The Matrix Resurrections",
                EnCartelera = true,
                Estreno = new DateTime(2100, 1, 1),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            builder.Entity(entidadGeneroPelicula).HasData(
              new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = acción.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = drama.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id }
          );

            builder.Entity(entidadSalaCinePelicula).HasData(
             new Dictionary<string, object> { [SalaCineIdPropiedad] = SalaCine2DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [SalaCineIdPropiedad] = SalaCine3DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [SalaCineIdPropiedad] = SalaCine2DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [SalaCineIdPropiedad] = SalaCine3DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [SalaCineIdPropiedad] = SalaCine2DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [SalaCineIdPropiedad] = SalaCine3DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [SalaCineIdPropiedad] = SalaCineCXCMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id }
         );


            var keanuReevesMatrix = new PeliculaActor
            {
                ActorId = keanuReeves.Id,
                PeliculaId = theMatrixResurrections.Id,
                Orden = 1,
                Personaje = "Neo"
            };

            var avengersChrisEvans = new PeliculaActor
            {
                ActorId = chrisEvans.Id,
                PeliculaId = avengers.Id,
                Orden = 1,
                Personaje = "Capitán América"
            };

            var avengersRobertDowney = new PeliculaActor
            {
                ActorId = robertDowney.Id,
                PeliculaId = avengers.Id,
                Orden = 2,
                Personaje = "Iron Man"
            };

            var avengersScarlettJohansson = new PeliculaActor
            {
                ActorId = scarlettJohansson.Id,
                PeliculaId = avengers.Id,
                Orden = 3,
                Personaje = "Black Widow"
            };

            var tomHollandFFH = new PeliculaActor
            {
                ActorId = tomHolland.Id,
                PeliculaId = farFromHome.Id,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var tomHollandNWH = new PeliculaActor
            {
                ActorId = tomHolland.Id,
                PeliculaId = noWayHome.Id,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var samuelJacksonFFH = new PeliculaActor
            {
                ActorId = samuelJackson.Id,
                PeliculaId = farFromHome.Id,
                Orden = 2,
                Personaje = "Samuel L. Jackson"
            };

            builder.Entity<Pelicula>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            builder.Entity<PeliculaActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);
        }
    }
}
