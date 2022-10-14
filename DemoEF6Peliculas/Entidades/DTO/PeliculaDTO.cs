namespace DemoEF6Peliculas.Entidades.DTO
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }


        public List<GeneroDTO> Generos { get; set; }
        public List<CineDTO> Cines { get; set; }
        public List<ActorDTO> Actores { get; set; }
    }
}
