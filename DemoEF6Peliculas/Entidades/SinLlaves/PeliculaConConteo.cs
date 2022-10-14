namespace DemoEF6Peliculas.Entidades.SinLlaves
{
    public class PeliculaConConteo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? CantidadGeneros { get; set; }
        public int? CantidadCines { get; set; }
        public int? CantidadActores { get; set; }
    }
}
