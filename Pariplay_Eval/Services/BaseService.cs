using Pariplay_Eval.Data;

namespace Pariplay_Eval.Services
{
    public abstract class BaseService
    {
        protected readonly EvalDbContext context;
        public BaseService(EvalDbContext context)
        {
            this.context = context;
        }
    }
}
