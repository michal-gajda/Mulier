namespace Mulier.WebApi;

using System.Net;
using Mulier.Application.Common.Exceptions;
using Mulier.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

internal sealed class ExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService service;

    public ExceptionHandler(IProblemDetailsService service)
        => this.service = service;
    
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
        
        return await this.service.TryWriteAsync(problemDetailsContext);
    }
}
