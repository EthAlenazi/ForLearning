using System.Text.Json;
using System.Text;

namespace Assignment6
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Method.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                await context.Response.WriteAsync("no response");
                return;
            }
            else
            {
                context.Request.EnableBuffering();

                using var reder = new StreamReader(context.Request.Body, Encoding.Default);
                var body = await reder.ReadToEndAsync();
                context.Response.StatusCode = 400;
                if (!string.IsNullOrEmpty(body))
                {
                    var data = JsonSerializer.Deserialize<JsonElement>(body);
                    var email = string.Empty;
                    var password = string.Empty;
                    if (data.TryGetProperty("email", out JsonElement emailelement))
                    {
                        email = emailelement.GetString();
                    }
                    else
                    {
                        await context.Response.WriteAsync("invalid input for 'email'");

                    }
                    if (data.TryGetProperty("password", out JsonElement passwordelement))
                    {
                        password = passwordelement.GetString();
                    }
                    else
                    {
                        await context.Response.WriteAsync("invalid input for 'password'");
                        return;
                    }
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                    {
                        if (email.Equals("admin@example.com") && password.Equals("admin1234"))
                        {
                            context.Response.StatusCode = 200;
                            await context.Response.WriteAsync("successful login");
                            return;

                        }
                        else
                        {
                            await context.Response.WriteAsync("invalid login");
                            return;

                        }

                    }

                }
                else
                {
                    await context.Response.WriteAsync("invalid input for 'email'");
                    await context.Response.WriteAsync("invalid input for 'password'");
                    return;

                }
            }
        }
          
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
