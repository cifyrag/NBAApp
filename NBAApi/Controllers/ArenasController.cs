 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;
using System.Drawing.Printing;
using System.Reflection.Metadata.Ecma335;

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

            foreach (var a in arenas)
            {
                a.State = _context.States.Where(u => u.Id == a.StateId).FirstOrDefault();
                a.Team = _context.Teams.Where(u => u.Id == a.TeamId).FirstOrDefault();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = arenas.Select(x => DTO_ArenaSummary.ToDTO_ArenaSummary(x)).ToList();
            return Ok(DTO_Arenas.ToDTO_Arenas(res, res.Count));
        }
        //GET api/Arenas/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_ArenaDetails))]
        public IActionResult GetArena( string id)
        {
            id = id.Trim().ToLower();
            if (!_context.Arenas.Any(c => c.Id.ToLower() == id))
                return NotFound();


            var arena = _context.Arenas
                .Where(a => a.Id.ToLower() == id)
                .FirstOrDefault();
            arena.State = _context.States.Where(u => u.Id == arena.StateId).FirstOrDefault();
            arena.Team = _context.Teams.Where(u => u.Id == arena.TeamId).FirstOrDefault();
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
            q = q.ToLower().Trim();
            var arenas = _context.Arenas
                .Where(x => (x.Name.Trim().ToLower()).Contains(q))
                .ToList();
            foreach (var a in arenas)
            {
                a.State = _context.States.Where(u => u.Id == a.StateId).FirstOrDefault();
                a.Team = _context.Teams.Where(u => u.Id == a.TeamId).FirstOrDefault();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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

            foreach (var a in arenas)
            {
                a.State = _context.States.Where(u => u.Id == a.StateId).FirstOrDefault();
                a.Team = _context.Teams.Where(u => u.Id == a.TeamId).FirstOrDefault();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_Arenas.ToDTO_Arenas(arenas.Select(x => DTO_ArenaSummary.ToDTO_ArenaSummary(x)).ToList(), page, pagesize));
        }
    }


}
