using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NetTopologySuite;
using NetTopologySuite.Geometries;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DemoEF6Peliculas.Entidades;
using DemoEF6Peliculas.Entidades.DTO;
using DemoEF6Peliculas.Entidades.SinLlaves;

namespace DemoEF6Peliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinesController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public CinesController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<CineDTO>>> GetAll()
        {
            if(context.Cines.Count() <= 0)
            {
                return NotFound();
            }

            return await context.Cines.ProjectTo<CineDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult> Search(double Latitud, double Longitud, double Distancia)
        {
            var geo = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var loc = geo.CreatePoint(new Coordinate(Longitud, Latitud));
            var cines = await context.Cines
                .Where(w => w.Ubicacion.IsWithinDistance(loc, Distancia*1000))
                .OrderBy(o => o.Ubicacion.Distance(loc))
                .Select(s => new
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Distancia = Math.Round(s.Ubicacion.Distance(loc), 1),
                    DistanciaKm = Math.Round(s.Ubicacion.Distance(loc) / 1000, 1)
                }).ToListAsync();
            
            return Ok(cines);
        }

        [HttpGet]
        [Route("SinUbicacion")]
        public async Task<List<CineSinUbicacion>> SinUbicacion()
        {
            //return await context.Set<CineSinUbicacion>().ToListAsync();
            return await context.CinesSinUbicacion.ToListAsync();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete(int Id)
        {
            var cine = await context.Cines.Include(c => c.Oferta).FirstOrDefaultAsync(x => x.Id == Id);

            if(cine is null)
            {
                return NotFound();
            }

            context.Remove(cine);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}

