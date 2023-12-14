﻿ 
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_SeasonTypes.ToDTO_SeasonTypes(seasonTypes.Select(x => DTO_SeasonTypeSummary.ToDTO_SeasonTypeSummary(x)).ToList()));
        }


        //GET api/SeasonTypes/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_SeasonTypeDetails))]
        public IActionResult GetSeasonType([FromQuery] int id)
        {
            if (!_context.SeasonTypes.Any(c => c.Id == id))
                return NotFound();

            var seasonType = _context.SeasonTypes
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(DTO_SeasonTypeDetails.ToDTO_SeasonTypeDetails(seasonType));
        }

    }
}
