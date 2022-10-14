using Microsoft.EntityFrameworkCore;

namespace DemoEF6Peliculas.Entidades
{
    public abstract class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Precision(18,2)]
        public decimal Precio { get; set; }

    }
}
