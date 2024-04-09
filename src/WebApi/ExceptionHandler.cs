namespace Mulier.WebApi;

using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mulier.Application.Common.Exceptions;
using Mulier.Domain.Exceptions;

internal sealed class ExceptionHandler(IProblemDetailsService service) : IExceptionHandler
{
    private readonly IProblemDetailsService problemDetailsService = service;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            ValidationException validationException => ((int)HttpStatusCode.BadRequest, validationException.Code),
            ApplicationException applicationException => ((int)HttpStatusCode.BadRequest, applicationException.Code),
            DomainException domainException => ((int)HttpStatusCode.BadRequest, domainException.Code),
            _ => ((int)HttpStatusCode.InternalServerError, string.Empty),
        };

        httpContext.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails
        {
            Title = title,
            Detail = exception.Message,
        };

        var problemDetailsContext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails,
        };

        return await this.problemDetailsService.TryWriteAsync(problemDetailsContext);
    }
}
