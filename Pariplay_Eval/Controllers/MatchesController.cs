using Microsoft.AspNetCore.Mvc;
using Pariplay_Eval.Data;
using Pariplay_Eval.DTO;
using Pariplay_Eval.Services.Interfaces;

namespace Pariplay_Eval.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesService matchesService;
        public MatchesController(IMatchesService service)
        {
            matchesService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = matchesService.GetMatches();
            if (result != null)
                return Ok(result);

            return NoContent();
        }
        
        // GET api/<MatchesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = matchesService.GetMatch(id);
            if (result is not null) 
                return Ok(result);

            return NoContent();
        }

        // POST api/<MatchesController>
        [HttpPost]
        public void Post([FromBody] MatchDTO match)
        {
            var matchToCreate = new Match()
            {
                HomeScore = match.HomeScore,
                AwayScore = match.AwayScore,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId,
                LeagueName = match.LeagueName
            };

            matchesService.CreateMatch(matchToCreate);
        }

        // PUT api/<MatchesController>/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] MatchDTO match)
        {
            var matchToUpdate = new Match()
            {
                HomeScore = match.HomeScore,
                AwayScore = match.AwayScore,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId,
                LeagueName = match.LeagueName
            };
            matchesService.UpdateMatch(id, matchToUpdate);
        }

        // DELETE api/<MatchesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            matchesService.DeleteMatch(id);
        }
    }
}
