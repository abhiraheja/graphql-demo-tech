using Demo2.Data;
using Demo2.Data.DummyData;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configurations = builder.Configuration;

string connectionString = configurations.GetConnectionString("default");

services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite(connectionString));
services.AddAutoMapper(Assembly.GetExecutingAssembly());

services.AddGraphQLServer();


var app = builder.Build();

app.UseHttpsRedirection();

app.CreateMockData();


app.MapGraphQL();
app.Run();
