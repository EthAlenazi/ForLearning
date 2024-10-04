
namespace WebApplication1
{
    public class CustomeMiddleware : IMiddleware
    {
      public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
          await  context.Response.WriteAsync( " @ grate @");
            await next(context);
           
        }
    }

    public static class Custome
    {

        public static IApplicationBuilder CallMiddleware(this IApplicationBuilder app)
        {
           return app.UseMiddleware<CustomeMiddleware>();
        }
    }
}
