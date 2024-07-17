var builder = WebApplication.CreateBuilder(args);

//before builder = add services to the container 

var app = builder.Build();

// after builder = configure the HTTP request pipeline 

app.Run();
