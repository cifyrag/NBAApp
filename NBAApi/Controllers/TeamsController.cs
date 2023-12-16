 
using Microsoft.AspNetCore.Mvc;
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;
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
            foreach (var a in teams)
            {
                a.State = _context.States.Where(u => u.Id == a.StateId).FirstOrDefault(); 
                a.Division = _context.Divisions.Where(u => u.Id == a.DivisionId).FirstOrDefault();
                a.Conference = _context.Conferences.Where(u => u.Id == a.ConferenceId).FirstOrDefault();
                var list = _context.Statistics.Where(u => u.TeamId == a.Id).ToList();
                foreach (var el in list)
                {
                    a.Statistics.Add(el);
                }
                
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList();
            return Ok(DTO_Teams.ToDTO_Teams(res, res.Count));
        }

        //GET api/Teams/{id}? acronym = { acronym }
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_TeamDetails))]
        public IActionResult GetTeam( string id, [FromQuery] string? acronym)
        {
            id = id.Trim().ToLower();
            if (!_context.Teams.Any(c => c.Id.ToLower() == id))
                return NotFound();

            var team = _context.Teams
                .Where(a => a.Id.ToLower() == id || a.Acronym== acronym)
                .FirstOrDefault();
            team.State = _context.States.Where(u => u.Id == team.StateId).FirstOrDefault();
            team.Division = _context.Divisions.Where(u => u.Id == team.DivisionId).FirstOrDefault();
            team.Conference = _context.Conferences.Where(u => u.Id == team.ConferenceId).FirstOrDefault();
            team.Statistics = _context.Statistics.Where(u => u.TeamId == team.Id).ToList();
            var list = _context.Statistics.Where(u => u.TeamId == team.Id).ToList();
            foreach (var el in list)
            {
                el.Team = _context.Teams.Where(u => u.Id == el.TeamId).FirstOrDefault();
                el.Team.State = _context.States.Where(u => u.Id == el.Team.StateId).FirstOrDefault();
                el.Team.Conference = _context.Conferences.Where(c => c.Id == el.Team.ConferenceId).FirstOrDefault();
                el.Team.Division = _context.Divisions.Where(c => c.Id == el.Team.DivisionId).FirstOrDefault();
                el.Player = _context.Players.Where(c => c.Id == el.PlayerId).FirstOrDefault();
                el.Player.Country = _context.Countries.Where(c => c.Id == el.Player.CountryId).FirstOrDefault();
                el.Player.Position = _context.Positions.Where(c => c.Id == el.Player.PositionId).FirstOrDefault();
                el.Year = _context.Years.Where(u => u.Id == el.YearId).FirstOrDefault();

                team.Statistics.Add(el);
            }
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
        public IActionResult SearchTeams([FromQuery] string q)
        {
            q = q.ToLower().Trim();
            var teams = _context.Teams
                .Where(x => x.Name.Trim().ToLower().Contains(q))
                .ToList();
            foreach (var a in teams)
            {
                a.State = _context.States.Where(u => u.Id == a.StateId).FirstOrDefault();
                a.Division = _context.Divisions.Where(u => u.Id == a.DivisionId).FirstOrDefault();
                a.Conference = _context.Conferences.Where(u => u.Id == a.ConferenceId).FirstOrDefault();
                var list = _context.Statistics.Where(u => u.TeamId == a.Id).ToList();
                foreach (var el in list)
                {
                    a.Statistics.Add(el);
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList());
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
            foreach (var a in teams)
            {
                a.State = _context.States.Where(u => u.Id == a.StateId).FirstOrDefault();
                a.Division = _context.Divisions.Where(u => u.Id == a.DivisionId).FirstOrDefault();
                a.Conference = _context.Conferences.Where(u => u.Id == a.ConferenceId).FirstOrDefault();
                var list = _context.Statistics.Where(u => u.TeamId == a.Id).ToList();
                foreach (var el in list)
                {
                    a.Statistics.Add(el);
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_Teams.ToDTO_Teams(teams.Select(x => DTO_TeamSummary.ToDTO_TeamSummary(x)).ToList(), page, pagesize));

        }


    }



}
