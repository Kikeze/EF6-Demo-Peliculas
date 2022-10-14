using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace DemoEF6Peliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }


        public CineOferta Oferta { get; set; }
        public List<SalaCine> SalasCine { get; set; }
        public CineDetalle CineDetalle { get; set; }
        public Direccion Direccion { get; set; }
    }
}
