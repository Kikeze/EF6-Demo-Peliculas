using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DemoEF6Peliculas.Entidades;
using DemoEF6Peliculas.Entidades.DTO;
using DemoEF6Peliculas.Entidades.SinLlaves;

namespace DemoEF6Peliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Pelicula>>> GetAll()
        {
            if(context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            return Ok(await context.Peliculas.ToListAsync());
        }

        [HttpGet]
        [Route("GetA")]
        public async Task<ActionResult<PeliculaDTO>> GetA(int Id)
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var pelicula = await context.Peliculas
                .Include(i => i.Generos.OrderByDescending(o => o.Nombre))
                .Include(i => i.SalasCine)
                    .ThenInclude(t => t.Cine)
                .Include(i => i.PeliculasActores)
                    .ThenInclude(t => t.Actor)
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (pelicula == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<PeliculaDTO>(pelicula);
            dto.Cines = dto.Cines.DistinctBy(d => d.Id).ToList();

            return Ok(dto);
        }

        [HttpGet]
        [Route("GetB")]
        public async Task<ActionResult<PeliculaDTO>> GetB(int Id)
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var pelicula = await context.Peliculas
                .ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (pelicula == null)
            {
                return NotFound();
            }

            pelicula.Cines = pelicula.Cines.DistinctBy(d => d.Id).ToList();

            return Ok(pelicula);
        }

        [HttpGet]
        [Route("GetC")]
        public async Task<ActionResult> GetC(int Id)
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var pelicula = await context.Peliculas.Select(s => new
            {
                Id = s.Id,
                Titulo = s.Titulo,
                Generos = s.Generos.OrderByDescending(o => o.Nombre).Select(s => new { Id = s.Id, Nombre = s.Nombre }).ToList(),
                CantidadActores = s.PeliculasActores.Count(),
                CantidadCines = s.SalasCine.Select(x => x.CineId).Distinct().Count()
            }).FirstOrDefaultAsync(f => f.Id == Id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        [HttpGet]
        [Route("GetD")]
        public async Task<ActionResult<Pelicula>> GetD(int Id)
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var pelicula = await context.Peliculas.AsTracking().FirstOrDefaultAsync(f => f.Id == Id);

            if (pelicula == null)
            {
                return NotFound();
            }

            await context.Entry(pelicula).Collection(c => c.Generos).LoadAsync();

            return Ok(pelicula);
        }

        [HttpGet]
        [Route("GetE")]
        public async Task<ActionResult> GetE(int Id)
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var pelicula = await context.Peliculas.AsTracking().FirstOrDefaultAsync(f => f.Id == Id);

            if (pelicula == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<PeliculaDTO>(pelicula);
            dto.Cines = dto.Cines.DistinctBy(d => d.Id).ToList();

            return Ok(dto);
        }

        [HttpGet]
        [Route("GroupedA")]
        public async Task<ActionResult> GroupedA()
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var peliculas = await context.Peliculas.GroupBy(g => g.EnCartelera)
                .Select(s => new
                {
                    EnCartelera = s.Key,
                    Conteo = s.Count(),
                    Peliculas = s.ToList()
                }).ToArrayAsync();

            if(!peliculas.Any())
            {
                return NotFound();
            }

            return Ok(peliculas);
        }

        [HttpGet]
        [Route("GroupedB")]
        public async Task<ActionResult> GroupedB()
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var peliculas = await context.Peliculas.GroupBy(g => g.Generos.Count())
                .Select(s => new
                {
                    Conteo = s.Key,
                    Titulos = s.Select(s => s.Titulo),
                    Generos = s.Select(s => s.Generos)
                        .SelectMany(m => m)
                        .Select(s => s.Nombre)
                        .Distinct()
                }).ToArrayAsync();

            if (!peliculas.Any())
            {
                return NotFound();
            }

            return Ok(peliculas);
        }

        [HttpGet]
        [Route("GroupedC")]
        public async Task<ActionResult<List<PeliculaDTO>>> GroupedC([FromQuery] PeliculasFiltroDTO filtro)
        {
            if (context.Peliculas.Count() <= 0)
            {
                return NotFound();
            }

            var query = context.Peliculas.AsQueryable();

            if(!string.IsNullOrEmpty(filtro.Titulo))
            {
                query = query.Where(w => w.Titulo.Contains(filtro.Titulo));
            }

            if(filtro.EnCartelera)
            {
                query = query.Where(w => w.EnCartelera);
            }

            if(filtro.ProximosEstrenos)
            {
                query = query.Where(w => w.Estreno >= DateTime.Now);
            }

            if(filtro.GeneroId >= 1)
            {
                query = query.Where(w => w.Generos.Select(s => s.Id).Contains(filtro.GeneroId));
            }

            var peliculas = await query.Include(i => i.Generos).ToListAsync();

            if(!peliculas.Any())
            {
                return NotFound();
            }

            var dto = mapper.Map<List<PeliculaDTO>>(peliculas);

            return Ok(dto);
        }

        [HttpGet]
        [Route("ConConteo")]
        public async Task<ActionResult<List<PeliculaConConteo>>> ConConteo()
        {
            return await context.Set<PeliculaConConteo>().ToListAsync();
        }

    }
}
