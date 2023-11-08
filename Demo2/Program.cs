using Demo2.Data;
using Demo2.Data.DummyData;
using Demo2.Data.Repository;
using Demo2.Graphql;
using Demo2.Graphql.Mutation;
using Demo2.Graphql.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configurations = builder.Configuration;

string connectionString = configurations.GetConnectionString("default");

services.AddScoped<ICourseRepository, CourseRepository>();

services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite(connectionString));
services.AddAutoMapper(Assembly.GetExecutingAssembly());

var graphqlServer = services.AddGraphQLServer();
graphqlServer.AddQueryType(x => x.Name("Query"));

graphqlServer.AddMutationType<CourseMutation>()
    .AddSubscriptionType<CourseSubscription>().AddInMemorySubscriptions();

Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsAssignableTo(typeof(QueryBase)) & !x.IsAbstract).ToList().ForEach(x =>
{
   graphqlServer.AddType(x);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.CreateMockData();

app.UseWebSockets();
app.MapGraphQL();
app.Run();
