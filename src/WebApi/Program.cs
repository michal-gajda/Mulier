using Microsoft.AspNetCore.Mvc;
using Mulier.Application;
using Mulier.Application.ToDos.Commands;
using Mulier.Infrastructure;
using Mulier.WebApi;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

#if Linux
builder.Host.UseSystemd();
#endif
#if Windows
builder.Host.UseWindowsService(options =>
{
    options.ServiceName = ServiceConstants.ServiceName;
});
#endif

builder.Logging.AddOpenTelemetry(options => options
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(ServiceConstants.ServiceName, serviceVersion: ServiceConstants.ServiceVersion))
    .AddConsoleExporter()
    .AddOtlpExporter()
);
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(ServiceConstants.ServiceName, serviceVersion: ServiceConstants.ServiceVersion))
    .WithTracing(tracing => tracing.AddAspNetCoreInstrumentation().AddConsoleExporter().AddOtlpExporter())
    .WithMetrics(metrics => metrics.AddAspNetCoreInstrumentation().AddConsoleExporter().AddOtlpExporter());

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

app.MapDelete("/todoitem", async ([FromQuery] Guid id, [FromQuery] Guid itemId, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(new RemoveToDoItem { Id = id, ItemId = itemId }, cancellationToken))
    .WithName("remove")
    .WithOpenApi();

app.MapPost("/todoitem", async ([FromBody] AddToDoItem command, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
    .WithName("add")
    .WithOpenApi();

await app.RunAsync();
