using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEF6Peliculas.Entidades
{
    public class Actor
    {
        //[Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }

        //[Column(TypeName = "DATETIME")]
        public DateTime? Nacimiento { get; set; }


        public List<PeliculaActor> PeliculasActores { get; set; }
        public Direccion DireccionHogar { get; set; }
        public Direccion DireccionTrabajo { get; set; }
    }
}
