 
using Microsoft.AspNetCore.Mvc;
using NBAApi.Data;
using NBAApi.Dto;
using System.Drawing.Printing;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public TeamsController(ApplicationDbContext context )
        {
            _context = context;
 
        }
        //GET api/Teams
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Teams))]
        public IActionResult GetTeams()
        {
            var teams =
                    _context.Teams
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Teams.ToDTO_Teams(teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList()));
        }

        //GET api/Teams/{id}? acronym = { acronym }
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_TeamDetails))]
        public IActionResult GetTeam([FromQuery] string id, [FromQuery] string acronym)
        {
            if (!_context.Teams.Any(c => c.Id == id))
                return NotFound();

            var team = _context.Teams
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_TeamDetails.ToDTO_TeamDetails(team));
        }

        //GET api/Teams/Search?q={q}
        [HttpGet]
        [Route("Search")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_TeamSummary>))]
        public IActionResult GetPlayersBySeason([FromQuery] string q)
        {
            var players = _context.Players
                .Where(x => (x.Name.Trim().ToLower()).Contains(q.Trim().ToLower()))
                .ToList();
            return Ok(players.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x)).ToList());
        }

        //GET api/Teams?page={page}&pagesize ={ pagesize}
        [HttpGet]
        [Route("Page")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Teams))]
        public IActionResult SearchTeams([FromQuery] int page, [FromQuery] int pagesize)
        {
            var teams =
                    _context.Teams
                        .OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_Teams.ToDTO_Teams(teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList(), page, pagesize));

        }


    }



}
