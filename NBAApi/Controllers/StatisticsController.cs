 
using Microsoft.AspNetCore.Mvc;
using NBAApi.Data;
using NBAApi.Dto;
using NBAApi.Models;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace NBAApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public StatisticsController(ApplicationDbContext context )
        {
            _context = context;
 
        }

        //GET api/Statistics/NumPlayersBySeason
        [HttpGet("NumPlayersBySeason")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_Statistics_NumPlayersBySeason>))]
        public IActionResult GetNumPlayersBySeason()
        {
            Dictionary<string, int> numOfPlayers = new Dictionary<string, int>();

            var statistics = _context.Statistics;
            foreach (var a in statistics)
            {
                a.Player = _context.Players.Where(u => u.Id == a.PlayerId).FirstOrDefault();
                a.SeasonType = _context.SeasonTypes.Where(u => u.Id == a.SeasonTypeId).FirstOrDefault();
                a.Team = _context.Teams.Where(u => u.Id == a.TeamId).FirstOrDefault();
                a.Year = _context.Years.Where(u => u.Id == a.YearId).FirstOrDefault();
            }

            foreach ( var statistic in statistics )
            {
                var season = statistic.Year.Season + " "+ statistic.SeasonType.Name;
                if (numOfPlayers.ContainsKey(season))
                {
                    numOfPlayers[season]++;
                }
                else
                {
                    numOfPlayers.Add(season, 1);
                }
            }

            List<DTO_Statistics_NumPlayersBySeason> result = new List<DTO_Statistics_NumPlayersBySeason>();

            foreach (KeyValuePair<string, int> season in numOfPlayers)
            {
                result.Add(DTO_Statistics_NumPlayersBySeason.ToDTO_Statistics_NumPlayersBySeason(season));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        //GET api/Statistics/PlayerRankBySeason?playerId={playerId}
        [HttpGet("PlayerRankBySeason")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_Statistics_PlayerRankBySeason>))]
        public IActionResult GetPlayerRankBySeason(string playerId)
        {
            var statistics = _context.Statistics
                .Where(x => x.Player.Id == playerId)
                .ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(statistics.Select(x => DTO_Statistics_PlayerRankBySeason.ToDTO_Statistics_PlayerRankBySeason(x)).ToList());
        }

        //GET api/Statistics/PlayersBySeason?seasonId={seasonId}&teamid={teamid}
        [HttpGet("PlayersBySeason")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(DTO_Statistics_PlayersBySeason))]
        public IActionResult GetPlayersBySeason(string seasonId, string teamid)
        {
            List<Player> players = new List<Player>();
            var statistics = _context.Statistics
                .Where(x => x.Year.Id == seasonId && x.Team.Id == teamid)
                .ToList();
            foreach (var a in statistics)
            {
                a.Player = _context.Players.Where(u => u.Id == a.PlayerId).FirstOrDefault();
                a.SeasonType = _context.SeasonTypes.Where(u => u.Id == a.SeasonTypeId).FirstOrDefault();
                a.Team = _context.Teams.Where(u => u.Id == a.TeamId).FirstOrDefault();
                a.Year = _context.Years.Where(u => u.Id == a.YearId).FirstOrDefault();
            }
            foreach (var statistic in statistics)
            {
                players.Add(statistic.Player);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(DTO_Statistics_PlayersBySeason.ToDTO_Statistics_PlayersBySeason(statistics.FirstOrDefault(), players));
        }

        //GET api/Statistics/Top5RankedPlayerByPlayoffSeason
        [HttpGet("Top5RankedPlayerByPlayoffSeason")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_Statistics_Top5RankedPlayerByPlayoffSeason>))]
        public IActionResult GetTop5RankedPlayerByPlayoffSeason()
        {
            var statistics = _context.Statistics
                .Where(x => x.SeasonType.Name == "Playoffs")
                .OrderByDescending(x => x.Rank)
                .Take(5)
                .ToList();
            foreach (var a in statistics)
            {
                a.Player = _context.Players.Where(u => u.Id == a.PlayerId).FirstOrDefault();
                a.SeasonType = _context.SeasonTypes.Where(u => u.Id == a.SeasonTypeId).FirstOrDefault();
                a.Team = _context.Teams.Where(u => u.Id == a.TeamId).FirstOrDefault();
                a.Year = _context.Years.Where(u => u.Id == a.YearId).FirstOrDefault();
            }
            Dictionary<string, List<Statistic>> players = new Dictionary<string, List<Statistic>>();

            foreach (var statistic in statistics)
            {
                var season = statistic.Year.Season;
                if (players.ContainsKey(season))
                {
                    players[season].Add(statistic);
                }
                else
                {
                    players.Add(season, new List<Statistic> { statistic });
                }
            }
            List<DTO_Statistics_Top5RankedPlayerByPlayoffSeason> result = new List<DTO_Statistics_Top5RankedPlayerByPlayoffSeason>();

            foreach (var el in players)
            {
                result.Add(DTO_Statistics_Top5RankedPlayerByPlayoffSeason.ToDTO_Statistics_Top5RankedPlayerByPlayoffSeason(el));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        //GET api/Statistics/Top5RankedPlayerByRegularSeason
        [HttpGet("Top5RankedPlayerByRegularSeason")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<DTO_Statistics_Top5RankedPlayerByRegularSeason>))]
        public IActionResult GetTop5RankedPlayerByRegularSeason()
        {
            var statistics = _context.Statistics
                .Where(x => x.SeasonType.Name == "Regular Season")
                .ToList();
            foreach (var a in statistics)
            {
                a.Player = _context.Players.Where(u => u.Id == a.PlayerId).FirstOrDefault();
                a.SeasonType = _context.SeasonTypes.Where(u => u.Id == a.SeasonTypeId).FirstOrDefault();
                a.Team = _context.Teams.Where(u => u.Id == a.TeamId).FirstOrDefault();
                a.Year = _context.Years.Where(u => u.Id == a.YearId).FirstOrDefault();
            }
            Dictionary<string, List<Statistic>> players = new Dictionary<string, List<Statistic>>();

            foreach (var statistic in statistics)
            {
                var season = statistic.Year.Season;
                if (players.ContainsKey(season))
                {
                    players[season].Add(statistic);
                }
                else
                {
                    players.Add(season, new List<Statistic> { statistic});
                }
            }
            List<DTO_Statistics_Top5RankedPlayerByRegularSeason> result = new List<DTO_Statistics_Top5RankedPlayerByRegularSeason>();

            foreach (var el in players)
            {
                result.Add(DTO_Statistics_Top5RankedPlayerByRegularSeason.ToDTO_Statistics_Top5RankedPlayerByRegularSeason(el));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(result);

        }

    }


}
