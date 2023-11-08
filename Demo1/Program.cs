using Demo1.Data;
using Demo1.Data.DummyData;
using Demo1.Data.Repository;
using Demo1.Graphql.Mutation;
using Demo1.Graphql.Queries;
using Demo1.Graphql.Subscription;
using Demo1.Helpers.DataLoaders;
using Demo1.Helpers.Resolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configurations = builder.Configuration;

string connectionString = configurations.GetConnectionString("default");

services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlite(connectionString).LogTo(Console.WriteLine));
services.AddAutoMapper(Assembly.GetExecutingAssembly());

// DataLoader Add
services.TryAddScoped<InstructorModel1DataLoader>();
services.TryAddScoped<CoursesByStudentIdDataLoader>();
services.TryAddScoped<SubjectsByCourseIdDataLoader>();



var graphqlserver = services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddType<SubjectDetailModel3Resolver>()
     .AddType<StudentDetailModelResolver>()
    .AddType<CourseDetailModelResolver>()
    .AddType<SubjectDetailModelResolver>()
    .AddInMemorySubscriptions();


// For Subscription

/// Simple way to add dataloader

//Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsAssignableTo(typeof(IDataLoader)) & !x.IsInterface).ToList().ForEach(x =>
//{
//    services.TryAddScoped(x);
//});



/// Simple way to add resolvers

//Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsAssignableTo(typeof(IObjectType)) & !x.IsInterface).ToList().ForEach(x =>
//{
//    graphqlserver.AddType(x);
//});


/// Simple way to add query, mutation, subscription 

//graphqlserver.AddQueryType(x => x.Name("Query"));
//graphqlserver.AddQueryType(x => x.Name("Mutation"));
//graphqlserver.AddQueryType(x => x.Name("Subscription"));
//Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsAssignableTo(typeof(QueryBase) || x.IsAssignableTo(typeof(MutationBase) || x.IsAssignableTo(typeof(SubscriptionBase)) & !x.IsAbstract).ToList().ForEach(x =>
//{
//    graphqlserver.AddType(x);
//});



services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<IInstructorRepository, InstructorRepository>();
services.AddScoped<ISubjectRepository, SubjectRepository>();
services.AddScoped<ICourseRepository, CourseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.CreateMockData();

// Subscription
app.UseWebSockets();

app.MapGraphQL();
app.Run();
