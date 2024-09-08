using Microsoft.AspNetCore.Mvc;
using Pariplay_Eval.Data;
using Pariplay_Eval.DTO;
using Pariplay_Eval.Services.Interfaces;

namespace Pariplay_Eval.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        public TeamsController(ITeamsService service)
        {
            _teamsService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _teamsService.GetTeams();
            if (result != null)
                return Ok(result);

            return NoContent();
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var result = _teamsService.GetTeam(id);
            if (result != null)
                return Ok(result);

            return NoContent();
        }

        // POST api/<TeamsController>
        [HttpPost]
        public void Post([FromBody] TeamDTO team)
        {
            var teamToCreate = new Team()
            {
                Name = team.Name,
            };
            _teamsService.CreateTeam(teamToCreate);
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] TeamDTO team)
        {
            var teamToUpdate = new Team()
            {
                Id = id,
                Name = team.Name,
            };
            _teamsService.UpdateTeam(id, teamToUpdate);
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _teamsService.DeleteTeam(id);
        }
    }
}
