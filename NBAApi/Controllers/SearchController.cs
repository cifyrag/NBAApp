 
using Microsoft.AspNetCore.Mvc;
using NBAApi.Data;
using NBAApi.Dto;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public SearchController(ApplicationDbContext context )
        {
            _context = context;
 
        }

        //GET api/Search? q = { q }&page={page}&pagesize={pagesize}
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Search))]
        public IActionResult GetSearchsPage([FromQuery] string q, [FromQuery] int page, [FromQuery] int pagesize)
        {
            return Ok();
        }

    }
}
