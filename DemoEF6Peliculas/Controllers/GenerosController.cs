using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DemoEF6Peliculas.Entidades;


namespace DemoEF6Peliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;

        public GenerosController(ApplicationDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Genero>>> GetAll()
        {
            dbcontext.Logs.Add(new Log()
            {
                Fecha = DateTime.Now,
                Mensaje = "GenerosController.GetAll"
            });
            await dbcontext.SaveChangesAsync();

            if(dbcontext.Generos.Count() <= 0)
            {
                return NotFound();
            }

            return Ok(await dbcontext.Generos.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        [Route("GetAllOrdered")]
        public async Task<ActionResult<List<Genero>>> GetAllOrdered()
        {
            dbcontext.Logs.Add(new Log()
            {
                Fecha = DateTime.Now,
                Mensaje = "GenerosController.GetAll"
            });
            await dbcontext.SaveChangesAsync();

            if (dbcontext.Generos.Count() <= 0)
            {
                return NotFound();
            }

            return Ok(await dbcontext.Generos.OrderByDescending(g => EF.Property<DateTime>(g, "FechaCreacion")).ToListAsync());
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {
            var genero = await dbcontext.Generos.Where(w => w.Id == Id).FirstOrDefaultAsync();

            if(genero is null)
            {
                return NotFound();
            }

            var creacion = dbcontext.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue;

            return Ok(new
            {
                Id = genero.Id,
                Nombre = genero.Nombre,
                Creacion = creacion
            });
        }

        [HttpGet]
        [Route("GetInQuery")]
        public async Task<ActionResult<Genero>> GetInQuery(int Id)
        {
            //var genero = await dbcontext.Generos.Where(w => w.Id == Id).FirstOrDefaultAsync();

            //var genero = await dbcontext.Generos
            //    .FromSqlRaw("select * from generos where id = {0}", Id)
            //    .IgnoreQueryFilters()
            //    .FirstOrDefaultAsync();

            var genero = await dbcontext.Generos
                .FromSqlInterpolated($"select * from generos where id = {Id}")
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync();

            if (genero is null)
            {
                return NotFound();
            }

            var creacion = dbcontext.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue;

            return Ok(new
            {
                Id = genero.Id,
                Nombre = genero.Nombre,
                Creacion = creacion
            });
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<List<Genero>>> Search(string query)
        {
            if (dbcontext.Generos.Count() <= 0 || string.IsNullOrEmpty(query))
            {
                return NotFound();
            }

            var lista = await dbcontext.Generos.AsNoTracking().Where(w => w.Nombre.Contains(query)).ToListAsync();

            if(lista.Count() <= 0)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult> Insert(Genero genero)
        {
            dbcontext.Add(genero);
            await dbcontext.SaveChangesAsync();

            return Ok(genero);
        }


    }
}
