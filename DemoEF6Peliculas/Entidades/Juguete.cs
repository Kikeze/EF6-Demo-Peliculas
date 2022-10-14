namespace DemoEF6Peliculas.Entidades
{
    public class Juguete : Producto
    {
        public bool Disponible { get; set; }
        public double Peso { get; set; }
        public double Volumen { get; set; }
        public bool esRopa { get; set; }
        public bool esColeccionable { get; set; }
    }
}
