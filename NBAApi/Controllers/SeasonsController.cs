 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonsController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public SeasonsController(ApplicationDbContext context )
        {
            _context = context;
 
        }
        //GET api/Seasons
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Seasons))]
        public IActionResult GetSeasons()
        {
            var seasons =
                     _context.Years
                         .OrderBy(a => a.Id)
                         .Take(50)
                         .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Seasons.ToDTO_Seasons(seasons.Select(x => DTO_SeasonSummary.ToDTO_SeasonSummary(x)).ToList()));
        }

        //GET api/Seasons/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_SeasonDetails))]
        public IActionResult GetSeason([FromQuery] string id)
        {
            if (!_context.Years.Any(c => c.Id == id))
                return NotFound();

            var season = _context.Years
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_SeasonDetails.ToDTO_SeasonDetails(season));
        }

        //GET api/Seasons/Search? q = { q }
        [HttpGet]
        [Route("Search")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_SeasonSummary>))]
        public IActionResult SearchSeason([FromQuery] string q)
        {
            var seasons = _context.Years
                .Where(x => (x.Season.Trim().ToLower()).Contains(q.Trim().ToLower()))
                .ToList();
            return Ok(seasons.Select(x => DTO_SeasonSummary.ToDTO_SeasonSummary(x)).ToList());

        }

        //GET api/Seasons? page = { page }&pagesize={pagesize}
        [HttpGet("/Page")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Seasons))]
        public IActionResult GetSeasonPage([FromQuery] int page, [FromQuery] int pagesize)
        {
            var seasons =
                    _context.Years
                        .OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_Seasons.ToDTO_Seasons(seasons.Select(x => DTO_SeasonSummary.ToDTO_SeasonSummary(x)).ToList(), page, pagesize));
        }
    }
}
