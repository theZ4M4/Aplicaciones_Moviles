using Microsoft.AspNetCore.Hosting;
using tarea1;

var builder = WebApplication.CreateBuilder(args);

var startup = new startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
var serviceLogger = (ILogger<startup>)app.Services.GetService(typeof(ILogger<startup>));
startup.Configure(app,app.Environment);

app.Run();
