using BuildingBlocks.Behavior;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//before builder = add services to the container 

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly); // command necessary to request the application 
    config.AddOpenBehavior(typeof(ValidationBehavior<,>)); // validation of the validation behavior method in generic form (,)
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!); 
}).UseLightweightSessions();

 

var app = builder.Build();  

// after builder = configure the HTTP request pipeline 

app.MapCarter(); 

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception == null)
        {
            return;
        }

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.StackTrace
        };

        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, exception.Message);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(problemDetails);
    });
}); // aspnet global exceptions error


app.Run();
