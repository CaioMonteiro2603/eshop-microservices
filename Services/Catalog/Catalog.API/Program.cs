var builder = WebApplication.CreateBuilder(args);

//before builder = add services to the container 

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly); // command necessary to request the application 
    config.AddOpenBehavior(typeof(ValidationBehavior<,>)); // validation of the validation behavior method in generic form (,)
    config.AddOpenBehavior(typeof(LoggingBehavior<,>)); // no necessary using log behavior in all cruds' class anymore 
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!); 
}).UseLightweightSessions();

if(builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>(); 
}

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

var app = builder.Build();  

// after builder.BUild = configure the HTTP request pipeline 

app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health", 
    new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    }); 

app.Run();
