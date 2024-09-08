namespace Pariplay_Eval.Middlewares.Exceptions
{
    internal class ExceptionHandlingContext
    {
        private IExceptionHandleStrategy _strategy;
        public ExceptionHandlingContext()
        {
            
        }
        public ExceptionHandlingContext(IExceptionHandleStrategy sorting)
        {
            _strategy = sorting;
        }
        public void SetStrategy(IExceptionHandleStrategy newStrategy) => _strategy = newStrategy;
        public void Handle(Exception exception)
        {
            _strategy?.Handle(exception);
        }
    }
}