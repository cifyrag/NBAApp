 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;

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
            var divisions =
                    _context.Divisions
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            foreach (var a in divisions)
            {
                var list = _context.Teams.Where(u => u.DivisionId == a.Id).ToList();
                foreach (var el in list)
                {
                    a.Teams.Add(el);
                }

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Divisions.ToDTO_Divisions(divisions.Select(x => DTO_DivisionSummary.ToDTO_DivisionSummary(x)).ToList()));

        }

        //GET api/Divisions/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_DivisionDetails))]
        public IActionResult GetDivision(string id)
        {

            if (!_context.Divisions.Any(c => c.Id == id))
                return NotFound();

            var division = _context.Divisions
                .Where(a => a.Id == id)
                .FirstOrDefault();
            var list = _context.Teams.Where(u => u.DivisionId == division.Id).ToList();
            foreach (var el in list)
            {
                division.Teams.Add(el);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_DivisionDetails.ToDTO_DivisionDetails(division));
        }
    }
}
