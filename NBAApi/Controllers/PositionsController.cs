 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;

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
        public IActionResult GetPosition([FromQuery] int id)
        {
            if (!_context.Positions.Any(c => c.Id == id))
                return NotFound();

            var position = _context.Positions
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_PositionDetails.ToDTO_PositionDetails(position));
        }
    }

}
