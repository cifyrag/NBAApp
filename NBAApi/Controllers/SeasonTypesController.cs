 
using Microsoft.AspNetCore.Mvc;
using NBAApi.Data;
using NBAApi.Dto;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public SeasonTypesController(ApplicationDbContext context )
        {
            _context = context;
 
        }
        //GET api/SeasonTypes
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_SeasonTypes))]
        public IActionResult GetSeasonTypes()
        {
            var seasonTypes =
                    _context.SeasonTypes
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            foreach (var a in seasonTypes)
            {
                a.Statistics = _context.Statistics.Where(u => u.SeasonTypeId == a.Id).ToList();
                foreach (var el in a.Statistics)
                {

                    el.Year = _context.Years.Where(u => u.Id == el.YearId).FirstOrDefault();

                    
                }

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = seasonTypes.Select(x => DTO_SeasonTypeSummary.ToDTO_SeasonTypeSummary(x)).ToList();
            return Ok(DTO_SeasonTypes.ToDTO_SeasonTypes(res, res.Count));
        }


        //GET api/SeasonTypes/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_SeasonTypeDetails))]
        public IActionResult GetSeasonType( string id)
        {
            id = id.Trim().ToLower();
            if (!_context.SeasonTypes.Any(c => c.Id.ToLower() == id))
                return NotFound();

            var seasonType = _context.SeasonTypes
                .Where(a => a.Id.ToLower() == id)
                .FirstOrDefault();
            seasonType.Statistics = _context.Statistics.Where(u => u.SeasonTypeId == seasonType.Id).ToList();
            foreach (var el in seasonType.Statistics)
            {
                el.Year = _context.Years.Where(u => u.Id == el.YearId).FirstOrDefault();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_SeasonTypeDetails.ToDTO_SeasonTypeDetails(seasonType));
        }

    }
}

