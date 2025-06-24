using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
Dictionary<int, string> keyValueCountries = new Dictionary<int, string>();
keyValueCountries[1] = "1.United States\n";
keyValueCountries[2] = "2.Canada\n";
keyValueCountries[3] = "3.United Kingdom\n";
keyValueCountries[4] = "4.India\n";
keyValueCountries[5] = "5.Japan\n";

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.MapGet("/countries", async (context) =>
    await context.Response.WriteAsync(string.Join(" ", keyValueCountries.Values)));

    endpoints.Map("/countries/{countryID:int}", async context => {
        
       int value = Convert.ToInt32( context.Request.RouteValues["countryID"]);
        if (value <= keyValueCountries.Count)
        {
            context.Response.WriteAsync($"{keyValueCountries[value]}");
        }
        else if (value > 100)
        {

            context.Response.StatusCode = 400;
            context.Response.WriteAsync("The CountryID should be between 1 and 100");
        }
        else
        context.Response.StatusCode = 404;
        context.Response.WriteAsync("[No Country]");
    });
    
    
    });
app.Run();
