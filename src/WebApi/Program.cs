using Microsoft.AspNetCore.Mvc;
using Mulier.Application;
using Mulier.Application.ToDos.Commands;
using Mulier.Infrastructure;
using Mulier.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/health");
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseInfrastructure();

app.MapPost("/todo", async ([FromBody] CreateToDo command, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
    .WithName("create")
    .WithOpenApi();

app.MapPut("/todoitem", async ([FromBody] ChangeToDoItem command, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
    .WithName("change")
    .WithOpenApi();

app.MapDelete("/todoitem", async ([FromQuery] Guid id, [FromQuery] Guid itemId, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(new RemoveToDoItem { Id = id, ItemId = itemId, }, cancellationToken))
    .WithName("remove")
    .WithOpenApi();

app.MapPost("/todoitem", async ([FromBody] AddToDoItem command, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
    .WithName("add")
    .WithOpenApi();

await app.RunAsync();
