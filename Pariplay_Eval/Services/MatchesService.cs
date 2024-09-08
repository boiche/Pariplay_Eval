using Pariplay_Eval.Data;
using Pariplay_Eval.Services.Interfaces;

namespace Pariplay_Eval.Services
{
    public class MatchesService : BaseService, IMatchesService
    {
        public MatchesService(EvalDbContext context) : base(context)
        {
        }

        public void CreateMatch(Match match)
        {
            match.Id = Guid.NewGuid();
            context.Matches.Add(match);
            context.SaveChanges();
            context.RaiseMatchAdded(this, new Data.Events.MatchAddedArgs { Match = match });
        }

        public void DeleteMatch(Guid id)
        {
            context.Matches.Remove(GetMatch(id));
            context.SaveChanges();
        }

        public Match? GetMatch(Guid id)
        {
            return context.Matches.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Match> GetMatches()
        {
            return context.Matches;
        }

        public void UpdateMatch(Guid id, Match match)
        {
            Match? toUpdate = GetMatch(id);
            if (toUpdate is null)
                return;

            // for simplicity here directly set the writeable prop. Better use AutoMapper or reflection in more complex use cases. Change detector should also be applicable because most of the time we want only what we change to change. What is not changed will be errased since it will come as 'default' value
            toUpdate.HomeScore = match.HomeScore;
            toUpdate.AwayScore = match.AwayScore;
            toUpdate.HomeTeamId = match.HomeTeamId;
            toUpdate.AwayTeamId = match.AwayTeamId;
            toUpdate.LeagueName = match.LeagueName;
            context.SaveChanges();
        }
    }
}
