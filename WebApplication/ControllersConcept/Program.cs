

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var app = builder.Build();

//app.UseRouting();
//app.UseEndpoints(endpoints =>   
//endpoints.MapControllers());

// or diract use MapControllers()
app.MapControllers();
app.Run();
