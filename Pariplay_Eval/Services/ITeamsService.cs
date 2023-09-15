using Pariplay_Eval.Data;

namespace Pariplay_Eval.Services
{
    public interface ITeamsService
    {
        void CreateTeam(Team team);
        void DeleteTeam(Guid id);
        Team? GetTeam(Guid id);
        void UpdateTeam(Team team);
    }
}
