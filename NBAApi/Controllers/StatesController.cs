 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NBAApi.Data;
using NBAApi.Dto;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public StatesController(ApplicationDbContext context )
        {
            _context = context;
 
        }
        //GET api/States
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_States))]
        public IActionResult GetStates()
        {
            var states =
                    _context.States
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_States.ToDTO_States(states.Select(x => DTO_StateSummary.ToDTO_StateSummary(x)).ToList()));
        }

        //GET api/States/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_StateDetails))]
        public IActionResult GetState([FromQuery] int id)
        {
            if (!_context.States.Any(c => c.Id == id))
                return NotFound();

            var state = _context.States
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_StateDetails.ToDTO_StateDetails(state));
        }

        //GET api/States/Search? q = { q }
        [HttpGet]
        [Route("Search")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_StateSummary>))]
        public IActionResult SearchState([FromQuery] string q)
        {
            var states = _context.States
                .Where(x => (x.Name.Trim().ToLower()).Contains(q.Trim().ToLower()))
                .ToList();
            return Ok(states.Select(x => DTO_StateSummary.ToDTO_StateSummary(x)).ToList());

        }

        //GET api/States? page = { page }&pagesize={pagesize}
        [HttpGet]
        [Route("Page")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_States))]
        public IActionResult GetStatesPage([FromQuery] int page, [FromQuery] int pagesize)
        {
            var states =
                    _context.States
                        .OrderBy(a => a.Id)
                        .Skip((page - 1) * pagesize)
                        .Take(pagesize)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_States.ToDTO_States(states.Select(x => DTO_StateSummary.ToDTO_StateSummary(x)).ToList(), page, pagesize));
        }

    }
}
