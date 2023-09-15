using Pariplay_Eval.Data;

namespace Pariplay_Eval.Services
{
    public class TeamsService : BaseService, ITeamsService
    {
        public TeamsService(EvalDbContext context) : base(context)
        {
        }

        public void CreateTeam(Team team)
        {
            team.Id = Guid.NewGuid();
            context.Teams.Add(team);
            context.SaveChanges();
        }

        public void DeleteTeam(Guid id)
        {
            this.context.Teams.Remove(GetTeam(id));
            context.SaveChanges();
        }

        public Team? GetTeam(Guid id)
        {
            return context.Teams.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateTeam(Team team)
        {
            Team? toUpdate = GetTeam(team.Id.Value);
            toUpdate = team;
            context.SaveChanges();
        }
    }
}
