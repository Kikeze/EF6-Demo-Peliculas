using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DemoEF6Peliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DemoEF6Peliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly ApplicationDBContext db;

        public PagosController(ApplicationDBContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("GetPagos")]
        public async Task<ActionResult<List<Pago>>> GetPagos()
        {
            var existe = await db.Pagos.AnyAsync();

            if(!existe)
            {
                return NotFound();
            }

            return Ok(await db.Pagos.ToListAsync());
        }

        [HttpGet]
        [Route("GetPagosTarjeta")]
        public async Task<ActionResult<List<PagoTarjeta>>> GetPagosTarjeta()
        {
            var existe = await db.Pagos.OfType<PagoTarjeta>().AnyAsync();

            if (!existe)
            {
                return NotFound();
            }

            return Ok(await db.Pagos.OfType<PagoTarjeta>().ToListAsync());
        }

        [HttpGet]
        [Route("GetPagosPaypal")]
        public async Task<ActionResult<List<PagoPaypal>>> GetPagosPaypal()
        {
            var existe = await db.Pagos.OfType<PagoPaypal>().AnyAsync();

            if (!existe)
            {
                return NotFound();
            }

            return Ok(await db.Pagos.OfType<PagoPaypal>().ToListAsync());
        }



    }
}
