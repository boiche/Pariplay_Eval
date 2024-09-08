
namespace Pariplay_Eval.Middlewares.Exceptions
{
    public interface IExceptionHandleStrategy
    {
        void Handle(Exception exception);
    }
}