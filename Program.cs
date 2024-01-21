var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
//app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        // Set cache control headers for HTML files
        if (context.Context.Response.ContentType == "text/html")
        {
            context.Context.Response.Headers.Add("Cache-Control", "no-store, no-cache, must-revalidate, max-age=0");
            context.Context.Response.Headers.Add("Pragma", "no-cache");
            context.Context.Response.Headers.Add("Expires", "Thu, 01 Jan 1970 00:00:00 GMT");
        }
    }
});

app.MapRazorPages();
app.Run();