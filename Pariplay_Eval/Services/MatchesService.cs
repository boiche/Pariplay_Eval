using Pariplay_Eval.Data;

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

        public void UpdateMatch(Match match)
        {
            Match toUpdate = GetMatch(match.Id.Value);
            toUpdate = match;
            context.SaveChanges();
        }
    }
}
