using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(options => options.LoggingFields = HttpLoggingFields.All);
builder.Services.AddHealthChecks();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseHttpLogging();
app.UseHealthChecks("/health");

app.MapReverseProxy();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapFallbackToFile("index.html");

await app.RunAsync();
