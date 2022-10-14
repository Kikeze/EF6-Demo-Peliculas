using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DemoEF6Peliculas.Entidades
{
    [Owned]
    public class Direccion
    {
        public string Calle { get; set; }
        public string Provincia { get; set; }
        [Required]
        public string Pais { get; set; }
    }
}
