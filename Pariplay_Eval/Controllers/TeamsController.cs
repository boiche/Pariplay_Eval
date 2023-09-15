using Microsoft.AspNetCore.Mvc;
using Pariplay_Eval.Data;
using Pariplay_Eval.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pariplay_Eval.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService teamsService;
        public TeamsController(ITeamsService service)
        {
            teamsService = service;
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public Team Get(Guid id)
        {
            return teamsService.GetTeam(id);
        }

        // POST api/<TeamsController>
        [HttpPost]
        public void Post([FromBody] Team team)
        {
            teamsService.CreateTeam(team);
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Team team)
        {
            teamsService.UpdateTeam(team);
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            teamsService.DeleteTeam(id);
        }
    }
}
