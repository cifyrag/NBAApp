 
using Microsoft.AspNetCore.Mvc;
 
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;
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
            foreach (var a in conferences)
            {
                var list = _context.Teams.Where(u => u.ConferenceId==a.Id).ToList();
                foreach(var el in list)
                {
                    a.Teams.Add(el);
                }
   
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = conferences.Select(x => DTO_ConferenceSummary.ToDTO_ConferenceSummary(x)).ToList();
            return Ok(DTO_Conference.ToDTO_Conference(res, res.Count));

        }


        //GET api/Conferences/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_ConferenceDetails))]
        public IActionResult GetConference(string id)
        {
            id = id.Trim().ToLower();
            if (!_context.Conferences.Any(c => c.Id.ToLower() == id))
                return NotFound();

            var conference = _context.Conferences
                .Where(a => a.Id.ToLower() == id)
                .FirstOrDefault();
            var list = _context.Teams.Where(u => u.ConferenceId == conference.Id).ToList();
            foreach (var el in list)
            {
                el.Conference = _context.Conferences.Where(c => c.Id == el.ConferenceId).FirstOrDefault();
                el.Division = _context.Divisions.Where(c => c.Id == el.DivisionId).FirstOrDefault();
                el.State = _context.States.Where(c => c.Id == el.StateId).FirstOrDefault();
                conference.Teams.Add(el);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_ConferenceDetails.ToDTO_ConferenceDetails(conference));
        }
    }



}