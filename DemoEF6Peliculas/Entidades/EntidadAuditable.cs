using System.ComponentModel.DataAnnotations;

namespace DemoEF6Peliculas.Entidades
{
    public class EntidadAuditable
    {
        //public DateTime? FechaCreacion { get; set; }
        [StringLength(150)]
        public string CreadoPor { get; set; }
        //public DateTime? FechaModificacion { get; set; }
        [StringLength(150)]
        public string ModificadorPor { get; set; }
        public bool Borrado { get; set; }
        //public DateTime? FechaBorrado { get; set; }
        [StringLength(150)]
        public string BorradoPor { get; set; }
    }
}
