using System.ComponentModel.DataAnnotations;


namespace DemoEF6Peliculas.Entidades
{
    public class CineDetalle
    {
        public int Id { get; set; }
        [Required]
        public DateTime Apertura { get; set; }
        public string Historia { get; set; }
        public string Valores { get; set; }
        public string Misiones { get; set; }
        public string Etica { get; set; }
        public Cine Cine { get; set; }

    }
}
