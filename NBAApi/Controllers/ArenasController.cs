 
using Microsoft.AspNetCore.Mvc;
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;
using System.Drawing.Printing;

namespace NBAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenasController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public ArenasController(ApplicationDbContext context )
        {
            _context = context;
 
        }


        //GET api/Arenas
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Arenas))]
        public IActionResult GetArenas()
        {
            var arenas =
                    _context.Arenas
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Arenas.ToDTO_Arenas(arenas.Select(x => DTO_ArenaSummary.ToDTO_ArenaSummary(x)).ToList()));
        }
        //GET api/Arenas/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_ArenaDetails))]
        public IActionResult GetArena([FromQuery] int id)
        {
            if (!_context.Arenas.Any(c => c.Id == id))
                return NotFound();

            var arena = _context.Arenas
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_ArenaDetails.ToDTO_ArenaDetails(arena));
        }
        //GET api/Arenas/Search?q={q}
        [HttpGet]
        [Route("Search")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_ArenaSummary>))]
        public IActionResult SearchArenas([FromQuery] string q)
        {
            var arenas = _context.Arenas
                .Where(x => (x.Name.Trim().ToLower()).Contains(q.Trim().ToLower()))
                .ToList();
            return Ok(arenas.Select(x => DTO_ArenaSummary.ToDTO_ArenaSummary(x)).ToList());
        }

        //GET api/Arenas?page={page}&pagesize={pagesize}
        //[HttpGet("?page={page}&pagesize ={ pagesize}")]
        [HttpGet]
        [Route("Page")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Arenas))]
        public IActionResult GetArenasPage([FromQuery] int page, [FromQuery] int pagesize)
        {
            var arenas =
                    _context.Arenas
                        .OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_Arenas.ToDTO_Arenas(arenas.Select(x => DTO_ArenaSummary.ToDTO_ArenaSummary(x)).ToList(), page, pagesize));
        }
    }


}
