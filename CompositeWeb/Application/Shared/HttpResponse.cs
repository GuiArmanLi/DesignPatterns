using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CompositeWeb.Application.Shared;

public record HttpResponse : IActionResult
{
    public HttpStatusCode HttpStatus { get; }
    public  object? Content { get; }
    public string? Message { get; }

    public HttpResponse(HttpStatusCode httpStatus, object content, string message = "Default message")
    {
        HttpStatus = httpStatus;
        Content = content;
        Message = message;
    }

    public HttpResponse(HttpStatusCode httpStatus, string message = "Default message")
    {
        HttpStatus = httpStatus;
        Message = message;
    }

    public HttpResponse(HttpStatusCode httpStatus)
    {
        HttpStatus = httpStatus;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var httpResponse = new HttpResponse(HttpStatus, Content!, Message!);

        var response = context.HttpContext.Response;
        response.StatusCode = (int)httpResponse.HttpStatus;
        response.ContentType = "application/json";

        await response.WriteAsync(
            JsonConvert.SerializeObject(httpResponse)
        );
    }
}