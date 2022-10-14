using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DemoEF6Peliculas.Entidades;
using DemoEF6Peliculas.Entidades.DTO;


namespace DemoEF6Peliculas.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Actor>>> GetAll()
        {
            if(context.Actores.Count() <= 0)
            {
                return NotFound();
            }

            //var actores = await context.Actores
            //    .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
            //    .ToListAsync();

            return Ok(await context.Actores.ToListAsync());
        }
    }

}
