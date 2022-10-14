namespace DemoEF6Peliculas.Entidades
{
    public class SalaCine
    {
        public int Id { get; set; }
        public TipoSalaCine Tipo { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        public Moneda Moneda { get; set; }


        public Cine Cine { get; set; }
        public List<Pelicula> Peliculas { get; set; }
    }
}
