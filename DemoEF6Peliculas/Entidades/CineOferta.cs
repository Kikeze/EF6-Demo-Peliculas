namespace DemoEF6Peliculas.Entidades
{
    public class CineOferta
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }
        public decimal Descuento { get; set; }
        public int? CineId { get; set; }

    }
}
