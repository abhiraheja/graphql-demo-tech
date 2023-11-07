using Demo3.Queries;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;
Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().CreateLogger();

builder.Logging.AddSerilog();
builder.Host.UseSerilog();

services.AddGraphQLServer().AddQueryType<MyQueries>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.MapGraphQL();

app.Run();

