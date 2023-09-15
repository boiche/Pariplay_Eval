using Newtonsoft.Json;
using Pariplay_Eval.Data;
using System.Text.RegularExpressions;

namespace Pariplay_Eval.Services
{
    public class LeaguesService : BaseService, ILeaguesService
    {
        public LeaguesService(EvalDbContext context) : base(context)
        {
        }

        public void CreateLeague(League league)
        {
            league.Id = Guid.NewGuid();
            context.Leagues.Add(league);
            context.SaveChanges();
        }

        public void DeleteLeague(Guid id)
        {
            context.Leagues.Remove(GetLeague(id));
        }

        public League GetLeague(Guid id)
        {
            return context.Leagues.FirstOrDefault(x => x.Id == id);
        }

        public List<Standing> GetStandings(Guid id)
        {
            return JsonConvert.DeserializeObject<List<Standing>>(GetLeague(id).Data);
        }
    }
}
