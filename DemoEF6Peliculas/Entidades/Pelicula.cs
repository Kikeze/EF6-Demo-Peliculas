using Microsoft.EntityFrameworkCore;

namespace DemoEF6Peliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime Estreno { get; set; }

        //[Unicode(false)]
        public string PosterURL { get; set; }


        public List<Genero> Generos { get; set; }
        public List<SalaCine> SalasCine { get; set; }
        public List<PeliculaActor> PeliculasActores { get; set; }
    }
}
