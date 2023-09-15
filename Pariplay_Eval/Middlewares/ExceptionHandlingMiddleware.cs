using System.Diagnostics;

namespace Pariplay_Eval.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
				await _next(context);
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
