namespace Pariplay_Eval.Middlewares.Exceptions
{
    public class InvalidOperationExceptionStrategy : IExceptionHandleStrategy
    {
        public void Handle(Exception exception)
        {
            var invalidOperationException = exception as InvalidOperationException;
            //log to file system, cloud service...
        }
    }
}
