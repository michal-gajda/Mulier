using Microsoft.AspNetCore.Mvc;
using Mulier.Application;
using Mulier.Application.ToDos.Commands;
using Mulier.Infrastructure;
using Mulier.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
};

app.MapPost("/todo", async ([FromBody] CreateToDo command, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
    .WithName("create")
    .WithOpenApi();

app.MapPost("/todoitem", async ([FromBody] AddToDoItem command, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
    .WithName("add")
    .WithOpenApi();

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(start: 1, count: 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(minValue: -20, maxValue: 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();

        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

await app.RunAsync();
