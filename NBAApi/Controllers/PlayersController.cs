﻿ 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;
using System.Drawing.Printing;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Players.ToDTO_Players(players.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x)).ToList()));

        }

        //GET api/Players/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_PlayerDetails))]
        public IActionResult GetPlayer([FromQuery]string id)
        {
            if (!_context.Players.Any(c => c.Id == id))
                return NotFound();

            var player = _context.Players
                .Where(a => a.Id == id)
                .FirstOrDefault();

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
        public IActionResult SearchPlayer([FromQuery]string q)
        {
            var players = _context.Players
                .Where(x => (x.Name.Trim().ToLower()).Contains(q.Trim().ToLower()))
                .ToList();
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_Players.ToDTO_Players(players.Select(x => DTO_PlayerSummary.ToDTO_PlayerSummary(x)).ToList(), page, pagesize));

        }
    }


}
