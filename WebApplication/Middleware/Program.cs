using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomeMiddleware>();
var app = builder.Build();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
await context.Response.WriteAsync("Atheer ....");
     await next(context);// in case we make as comment this line the result will be Atheer ....
});

app.UseMiddleware<CustomeMiddleware>();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync(" Alenazi....");
    await next(context);
});


app.CallMiddleware();

app.Run();

// 

