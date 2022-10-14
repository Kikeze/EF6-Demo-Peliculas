using Microsoft.EntityFrameworkCore;


namespace DemoEF6Peliculas.Entidades.SinLlaves
{
    //[Keyless]
    public class CineSinUbicacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
