using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SampleMiddleware.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var name = context.Session.GetString("Name");
            var isLogin = context.Request.Path.ToString().ToLower().Contains("login");
            var isError = context.Request.Path.ToString().ToLower().Contains("error");

            if (!isError && !isLogin && string.IsNullOrEmpty(name))
            {               
                context.Response.Redirect("/auth/login");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
