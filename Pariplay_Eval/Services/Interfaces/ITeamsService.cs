using Pariplay_Eval.Data;

namespace Pariplay_Eval.Services.Interfaces
{
    public interface ITeamsService
    {
        void CreateTeam(Team team);
        void DeleteTeam(Guid id);
        Team? GetTeam(Guid id);
        IEnumerable<Team> GetTeams();
        void UpdateTeam(Guid id, Team team);
    }
}
