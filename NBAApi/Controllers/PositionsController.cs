 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public PositionsController(ApplicationDbContext context )
        {
            _context = context;
 
        }
        //GET api/Positions
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Positions))]
        public IActionResult GetPositions()
        {
            var positions =
                    _context.Positions
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            foreach (var a in positions)
            {
                var list = _context.Players.Where(u => u.PositionId == a.Id).ToList();
                foreach (var el in list)
                {
                    a.Players.Add(el);
                }

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Positions.ToDTO_Positions(positions.Select(x => DTO_PositionSummary.ToDTO_PositionSummary(x)).ToList()));
        }
        //GET api/Positions/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_PositionDetails))]
        public IActionResult GetPosition( string id)
        {
            if (!_context.Positions.Any(c => c.Id == id))
                return NotFound();

            var position = _context.Positions
                .Where(a => a.Id == id)
                .FirstOrDefault();
            var list = _context.Players.Where(u => u.PositionId == position.Id).ToList();
            foreach (var el in list)
            {
                position.Players.Add(el);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_PositionDetails.ToDTO_PositionDetails(position));
        }
    }

}
