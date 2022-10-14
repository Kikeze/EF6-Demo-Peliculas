using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEF6Peliculas.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [InverseProperty("Emisor")]
        public List<Mensaje> MensajeEnviados { get; set; }

        [InverseProperty("Receptor")]
        public List<Mensaje> MensajeRecibidos { get; set; }

    }
}
