namespace DemoEF6Peliculas.Entidades.DTO
{
    public class PeliculasFiltroDTO
    {
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public bool EnCartelera { get; set; }
        public bool ProximosEstrenos { get; set; }
    }
}
