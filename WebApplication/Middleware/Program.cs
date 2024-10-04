using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Middleware;
using Middleware.Extencation;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomeMiddleware>(); //added as extencations
var app = builder.Build();
//this is the correct order to add middleware 
//app.UseExceptionHandler();
//app.UseHsts();
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseCors();
//app.UseAuthentication();
//app.UseAuthorization();
//app.MapControllers();
//after that we add my own custom middleware
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Atheer ...."); 
    await next(context);// in case we make as comment this line the result will be Atheer ....
});//added as lamda excpration 

app.UseMiddleware<CustomeMiddleware>();//added as middleware class 

app.Use(async (HttpContext context, RequestDelegate next) => 
{
    await context.Response.WriteAsync("Alenazi....");
    await next(context);
});//added as lamda excpration 

app.CallMiddleware();//added as extencations

app.UseConventionalMiddleware(); //added as conventional middleware class

app.UseWhen(
    context => context.Request.Query.ContainsKey("Data"),//if()
app =>
{
    app.Use(async (HttpContext context, RequestDelegate next) =>
    {
        var url = context.Request.Path;
        await context.Response.WriteAsync($"\n the url will be{url} ");
        await next(context);
    });
});
//the responce will be 
//Atheer .... @ grate @Alenazi.... @ grate @
//in this case the url must have contain Data Key
//the url will be / weatherforecast


app.Run();

//the result will be
//Atheer .... @ great @ Alenazi.... @ great @

