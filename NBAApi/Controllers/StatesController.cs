 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;

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
            foreach (var a in states)
            {
                a.Arenas = _context.Arenas.Where(u => u.StateId == a.Id).ToList();
                a.Teams = _context.Teams.Where(u => u.StateId == a.Id).ToList();
                //foreach (var el in a.Arenas)
                //{
                //    a.Arenas.Add(el);
                //}
                //foreach (var el in list2)
                //{
                //    a.Teams.Add(el);
                //}


            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = states.Select(x => DTO_StateSummary.ToDTO_StateSummary(x)).ToList();
            return Ok(DTO_States.ToDTO_States(res, res.Count));
        }

        //GET api/States/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_StateDetails))]
        public IActionResult GetState( string id)
        {
            id = id.Trim().ToLower();
            if (!_context.States.Any(c => c.Id.ToLower() == id))
                return NotFound();

            var state = _context.States
                .Where(a => a.Id.ToLower() == id)
                .FirstOrDefault();
            state.Arenas = _context.Arenas.Where(u => u.StateId == state.Id).ToList();
            
            
            foreach (var el in state.Arenas)
            {
                el.State = _context.States.Where(u => u.Id == el.StateId).FirstOrDefault();
                el.Team = _context.Teams.Where(u => u.Id == el.TeamId).FirstOrDefault();

            }
            state.Teams = _context.Teams.Where(u => u.StateId == state.Id).ToList();
            foreach (var a in state.Teams)
            {
                a.State = _context.States.Where(u => u.Id == a.StateId).FirstOrDefault();
                a.Division = _context.Divisions.Where(u => u.Id == a.DivisionId).FirstOrDefault();
                a.Conference = _context.Conferences.Where(u => u.Id == a.ConferenceId).FirstOrDefault();
                
            }

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
            foreach (var a in states)
            {
                a.Arenas = _context.Arenas.Where(u => u.StateId == a.Id).ToList();
                a.Teams = _context.Teams.Where(u => u.StateId == a.Id).ToList();
                //foreach (var el in a.Arenas)
                //{
                //    a.Arenas.Add(el);
                //}
                //foreach (var el in list2)
                //{
                //    a.Teams.Add(el);
                //}


            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            foreach (var a in states)
            {
                a.Arenas = _context.Arenas.Where(u => u.StateId == a.Id).ToList();
                a.Teams = _context.Teams.Where(u => u.StateId == a.Id).ToList();
                //foreach (var el in a.Arenas)
                //{
                //    a.Arenas.Add(el);
                //}
                //foreach (var el in list2)
                //{
                //    a.Teams.Add(el);
                //}


            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(DTO_States.ToDTO_States(states.Select(x => DTO_StateSummary.ToDTO_StateSummary(x)).ToList(), page, pagesize));
        }

    }
}
