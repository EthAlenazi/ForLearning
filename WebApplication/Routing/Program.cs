var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Use(async (context, next) => {
    Endpoint? endpoint = context.GetEndpoint();// return details for the request if route is found, allwas will be null 
    if (endpoint != null)
        await context.Response.WriteAsync($"{endpoint.DisplayName} , {endpoint.RequestDelegate.ToString()},{endpoint.Metadata}");
    await next();
});
app.UseRouting(); // for find the route 

app.Use(async (context, next) => {
    Endpoint? endpoint = context.GetEndpoint();// return details for the request if route is found
    if (endpoint != null)
        await context.Response.WriteAsync($"{endpoint.DisplayName} , {endpoint.RequestDelegate},{endpoint.Metadata}");
    await next();
});
app.UseEndpoints(endpoints => // for the excute the route
endpoints.MapGet("api/product/{id}",async
   ( context)=>{
       await context.Response.WriteAsync("\n your are in api/product/{id}");
    }));

app.UseEndpoints(endpoints => // for the excute the route
endpoints.MapGet("api/product/{id?}", async
   (context) => {
       await context.Response.WriteAsync("\n your are in api/product/{id?}!!");
   }));
app.UseEndpoints(endpoints => // for the excute the route
endpoints.MapGet("api/product/{id:int}", async
   (context) => {
       await context.Response.WriteAsync("\n your are in api/product/{id:int}!!");
   }));
app.UseEndpoints(endpoints =>
endpoints.MapGet("api/data/{note:alpha:length(1,5)}", async
   (context) => {
       await context.Response.WriteAsync(" your are in alpha:length!!");//Route Constraints
   }));
app.UseStaticFiles();//mvc project
app.Run(context=>context.Response.WriteAsync("This url not correct!"));//for the default route
app.Run();