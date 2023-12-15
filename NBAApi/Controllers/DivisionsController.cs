 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DivisionsController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public DivisionsController(ApplicationDbContext context )
        {
            _context = context;
 
        }

        //GET api/Divisions
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Divisions))]
        public IActionResult GetDivisions()
        {
            var arenas =
                    _context.Divisions
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Divisions.ToDTO_Divisions(arenas.Select(x => DTO_DivisionSummary.ToDTO_DivisionSummary(x)).ToList()));

        }

        //GET api/Divisions/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_DivisionDetails))]
        public IActionResult GetDivision([FromQuery]string id)
        {

            if (!_context.Divisions.Any(c => c.Id == id))
                return NotFound();

            var division = _context.Divisions
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_DivisionDetails.ToDTO_DivisionDetails(division));
        }
    }
}
