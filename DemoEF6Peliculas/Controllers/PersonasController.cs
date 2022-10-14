using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DemoEF6Peliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DemoEF6Peliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public PersonasController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Persona>>> GetAll()
        {
            var existe = await context.Peliculas.AnyAsync();
            if (!existe)
            {
                return NotFound();
            }

            return Ok(await context.Personas
                .Include(p => p.MensajeEnviados)
                .Include(p => p.MensajeRecibidos)
                .ToListAsync());
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Persona>> Get(int Id)
        {
            var existe = await context.Personas.AnyAsync(x => x.Id == Id);
            if (!existe)
            {
                return NotFound();
            }

            return Ok(await context.Personas
                .Include(p => p.MensajeEnviados)
                .Include(p => p.MensajeRecibidos)
                .FirstOrDefaultAsync(x => x.Id == Id));
        }
    }
}
