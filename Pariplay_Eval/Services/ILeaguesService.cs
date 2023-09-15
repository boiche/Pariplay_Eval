using Pariplay_Eval.Data;

namespace Pariplay_Eval.Services
{
    public interface ILeaguesService
    {
        void CreateLeague(League league);
        void DeleteLeague(Guid id);
        League GetLeague(Guid id);
        List<Standing> GetStandings(Guid id);
    }
}
