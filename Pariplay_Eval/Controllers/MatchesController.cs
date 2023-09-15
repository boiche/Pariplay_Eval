using Microsoft.AspNetCore.Mvc;
using Pariplay_Eval.Data;
using Pariplay_Eval.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        
        // GET api/<MatchesController>/5
        [HttpGet("{id}")]
        public Match Get(Guid id)
        {
            return matchesService.GetMatch(id);
        }

        // POST api/<MatchesController>
        [HttpPost]
        public void Post([FromBody] Match match)
        {
            matchesService.CreateMatch(match);
        }

        // PUT api/<MatchesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Match match)
        {
            matchesService.UpdateMatch(match);
        }

        // DELETE api/<MatchesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            matchesService.DeleteMatch(id);
        }
    }
}
