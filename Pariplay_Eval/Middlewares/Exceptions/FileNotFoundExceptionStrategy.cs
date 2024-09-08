
namespace Pariplay_Eval.Middlewares.Exceptions
{
    internal class FileNotFoundExceptionStrategy : IExceptionHandleStrategy
    {
        public void Handle(Exception e)
        {
            var exception = e as FileNotFoundException;
            // handle file not found exception
        }
    }
}