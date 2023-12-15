 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;
using System.Diagnostics;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConferencesController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public ConferencesController(ApplicationDbContext context )
        {
            _context = context;
 
        }
        //GET api/Conferences
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Conference))]
        public IActionResult GetConferences()
        {
            var conferences =
                    _context.Conferences
                        .OrderBy(a => a.Name)
                        .Take(50)
                        .ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_Conference.ToDTO_Conference(conferences.Select(x => DTO_ConferenceSummary.ToDTO_ConferenceSummary(x)).ToList()));

        }


        //GET api/Conferences/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_ConferenceDetails))]
        public IActionResult GetConference([FromQuery]string id)
        {
            if (!_context.Conferences.Any(c => c.Id == id))
                return NotFound();

            var conference = _context.Conferences
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_ConferenceDetails.ToDTO_ConferenceDetails(conference));
        }
    }



}