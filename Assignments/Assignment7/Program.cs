var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
var app = builder.Build();

app.Use(async (context, next) => {
    var data= context.GetEndpoint();
    await next();
}
);
app.UseRouting();
//app.MapGet("/", () => "Hello World!");
//app.MapControllers();
app.Use(async (context, next) => {
    var data = context.GetEndpoint();
    await next();
}
);
app.UseEndpoints(
    endpoints => {

        endpoints.Map("/", async (context) => {
            await context.Response.WriteAsync("Hello word");
        });
        endpoints.Map("/api", async (context) => {
            await context.Response.WriteAsync("Hello word");
        });
        endpoints.MapGet("/", async (context) => {
            await context.Response.WriteAsync("Hello word from get Method");
        });
 
    });
    app.Run();