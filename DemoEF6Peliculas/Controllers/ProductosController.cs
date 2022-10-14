using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DemoEF6Peliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DemoEF6Peliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDBContext db;

        public ProductosController(ApplicationDBContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("GetProductos")]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var existe = await db.Productos.AnyAsync();

            if(!existe)
            {
                return NotFound();
            }

            return await db.Productos.ToListAsync();
        }

        [HttpGet]
        [Route("GetPeliculas")]
        public async Task<ActionResult<List<PeliculaAlquilable>>> GetPeliculas()
        {
            var existe = await db.Set<PeliculaAlquilable>().AnyAsync();

            if (!existe)
            {
                return NotFound();
            }

            return await db.Set<PeliculaAlquilable>().ToListAsync();
        }

        [HttpGet]
        [Route("GetJuguetes")]
        public async Task<ActionResult<List<Juguete>>> GetJuguetes()
        {
            var existe = await db.Set<Juguete>().AnyAsync();

            if (!existe)
            {
                return NotFound();
            }

            return await db.Set<Juguete>().ToListAsync();
        }

    }
}
