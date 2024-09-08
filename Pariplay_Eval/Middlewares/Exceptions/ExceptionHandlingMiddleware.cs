using System.Diagnostics;

namespace Pariplay_Eval.Middlewares.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ExceptionHandlingContext _handlingContext;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
            _handlingContext = new();
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (InvalidOperationException e)
            {
                _handlingContext.SetStrategy(new InvalidOperationExceptionStrategy());
                _handlingContext.Handle(e);
            }
            catch (FileNotFoundException e)
            {
                _handlingContext.SetStrategy(new FileNotFoundExceptionStrategy());
                _handlingContext.Handle(e);
            }
            catch (Exception e)
            {
                do
                {
                    Debug.WriteLine(e.Message);
                    e = e.InnerException;
                }
                while (e != null);
            }
        }
    }
}
