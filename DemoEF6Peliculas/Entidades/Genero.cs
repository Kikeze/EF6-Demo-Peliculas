﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;


namespace DemoEF6Peliculas.Entidades
{
    //[Index(nameof(Nombre), IsUnique = true)]
    public class Genero
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool EstaBorrado { get; set; }

        public List<Pelicula> Peliculas { get; set; }
    }
}
