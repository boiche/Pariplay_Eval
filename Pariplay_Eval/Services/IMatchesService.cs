using Pariplay_Eval.Data;

namespace Pariplay_Eval.Services
{
    public interface IMatchesService
    {
        void CreateMatch(Match match);
        void DeleteMatch(Guid id);
        Match? GetMatch(Guid id);
        void UpdateMatch(Match match);
    }
}
