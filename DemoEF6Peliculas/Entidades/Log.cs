using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEF6Peliculas.Entidades
{
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }

        [NotMapped]
        public object Tag { get; set; }

    }
}
