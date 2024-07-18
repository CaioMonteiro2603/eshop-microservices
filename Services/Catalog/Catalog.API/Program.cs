var builder = WebApplication.CreateBuilder(args);

//before builder = add services to the container 
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly); // command necessary to request the application 
}); 

var app = builder.Build();  

// after builder = configure the HTTP request pipeline 

app.MapCarter(); 

app.Run();
