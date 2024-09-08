using Microsoft.EntityFrameworkCore;
using Pariplay_Eval.Data;
using Pariplay_Eval.Services.Interfaces;

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

        public IEnumerable<Team> GetTeams()
        {
            return context.Teams.Include(x => x.Standings).Include(x => x.Matches);
        }

        public void UpdateTeam(Guid id, Team team)
        {
            Team? toUpdate = GetTeam(id);
            if (toUpdate is null)
                return;

            // for simplicity here directly set the writeable prop. Better use AutoMapper or reflection in more complex use cases.
            toUpdate.Name = team.Name;            
            context.SaveChanges();
        }
    }
}
