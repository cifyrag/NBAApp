 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;
using System.Drawing.Printing;
using System.Net.WebSockets;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public PlayersController(ApplicationDbContext context )
        {
            _context = context;
 
        }
        //GET api/Players
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Players))]
        public IActionResult GetPlayers()
        {
            var players =
                    _context.Players
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            foreach (var a in players)
            {
                a.Country = _context.Countries.Where(u => u.Id == a.CountryId).FirstOrDefault();
                a.Position = _context.Positions.Where(u => u.Id == a.PositionId).FirstOrDefault();
                var list = _context.Statistics.Where(u => u.SeasonTypeId == a.Id).ToList();
                foreach (var el in list)
                {
                    a.Statistics.Add(el);
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = players.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x)).ToList();
            return Ok(DTO_Players.ToDTO_Players(res, res.Count));

        }

        //GET api/Players/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_PlayerDetails))]
        public IActionResult GetPlayer( string id)
        {
            id = id.Trim().ToLower();
            if (!_context.Players.Any(c => c.Id.ToLower() == id))
                return NotFound();

            var player = _context.Players
                .Where(a => a.Id.ToLower() == id)
                .FirstOrDefault();
            player.Country = _context.Countries.Where(u => u.Id == player.CountryId).FirstOrDefault();
            player.Position = _context.Positions.Where(u => u.Id == player.PositionId).FirstOrDefault();
            var list = _context.Statistics.Where(u => u.PlayerId == player.Id).ToList();
            foreach (var el in list)
            {
                el.Team = _context.Teams.Where(u => u.Id == el.TeamId).FirstOrDefault();
                el.Team.State = _context.States.Where(u => u.Id == el.Team.StateId).FirstOrDefault();
                el.Team.Conference = _context.Conferences.Where(c => c.Id == el.Team.ConferenceId).FirstOrDefault();
                el.Team.Division = _context.Divisions.Where(c => c.Id == el.Team.DivisionId).FirstOrDefault();

                el.Year = _context.Years.Where(u => u.Id == el.YearId).FirstOrDefault();
                player.Statistics.Add(el);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_PlayerDetails.ToDTO_PlayerDetails(player));
        }

        //GET api/Players/Search?q={q}
        [HttpGet]
        [Route("Search")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_PlayerSummary>))]
        public IActionResult SearchPlayer([FromQuery] string q)
        {
            q = q.ToLower().Trim();
            var players = _context.Players
                .Where(x => (x.Name.Trim().ToLower()).Contains(q))
                .ToList();
            foreach (var a in players)
            {
                a.Country = _context.Countries.Where(u => u.Id == a.CountryId).FirstOrDefault();
                a.Position = _context.Positions.Where(u => u.Id == a.PositionId).FirstOrDefault();
                var list = _context.Statistics.Where(u => u.SeasonTypeId == a.Id).ToList();
                foreach (var el in list)
                {
                    el.Team = _context.Teams.Where(u => u.Id == el.TeamId).FirstOrDefault();
                el.Team.State = _context.States.Where(u => u.Id == el.Team.StateId).FirstOrDefault();
                el.Team.Conference = _context.Conferences.Where(c => c.Id == el.Team.ConferenceId).FirstOrDefault();
                el.Team.Division = _context.Divisions.Where(c => c.Id == el.Team.DivisionId).FirstOrDefault();

                el.Year = _context.Years.Where(u => u.Id == el.YearId).FirstOrDefault();
                
                    a.Statistics.Add(el);
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(players.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x)).ToList());

        }

        //GET api/Players?page={page}&pagesize ={ pagesize}
        [HttpGet]
        [Route("Page")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Players))]
        public IActionResult GetPlayersPage([FromQuery] int page, [FromQuery] int pagesize)
        {
            var players =
                    _context.Players
                        .OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList();
            var playersCount =
                    _context.Players
                        .OrderBy(a => a.Id)
                        .ToList().Count;
            foreach (var a in players)
            {
                a.Country = _context.Countries.Where(u => u.Id == a.CountryId).FirstOrDefault();
                a.Position = _context.Positions.Where(u => u.Id == a.PositionId).FirstOrDefault();
                var list = _context.Statistics.Where(u => u.SeasonTypeId == a.Id).ToList();
                foreach (var el in list)
                {
                    a.Statistics.Add(el);
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_Players.ToDTO_Players(players.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x)).ToList(), playersCount, page, pagesize));

        }
    }


}
