using Microsoft.AspNetCore.Mvc;
using Pariplay_Eval.Data;
using Pariplay_Eval.Services;

namespace Pariplay_Eval.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeaguesService leaguesService;
        public LeaguesController(ILeaguesService service)
        {
            leaguesService = service;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public League Get(Guid id)
        {
            return leaguesService.GetLeague(id);
        }

        [HttpGet]
        public List<Standing> GetStandings(Guid id)
        {
            return leaguesService.GetStandings(id);
        }

        [HttpPost]
        public void Post([FromBody] League league)
        {
            leaguesService.CreateLeague(league);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            leaguesService.DeleteLeague(id);
        }
    }
}
