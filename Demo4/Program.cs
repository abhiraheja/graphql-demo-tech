using Demo4.Graphql.Base;
using Raven.Client.Documents;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

var graphqlserver = services.AddGraphQLServer();

var cert = new X509Certificate2("uk-dev.emrgroup.client.certificate.with.password.pfx", "3922FD4111EC2C99571775AAF2959AD");

services.AddSingleton<IDocumentStore>(_ => new DocumentStore
{
    Urls = new[] { "https://a.uk-dev.emrgroup.ravendb.cloud" },
    Database = "india-11",
    Certificate = cert
}.Initialize());


graphqlserver.AddQueryType(x => x.Name("Query"));
// graphqlserver.AddQueryType(x => x.Name("Mutation"));
// graphqlserver.AddQueryType(x => x.Name("Subscription"));

Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsAssignableTo(typeof(QueryBase)) && !x.IsAbstract).ToList().ForEach(x =>
{
    graphqlserver.AddType(x);
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGraphQL();


app.Run();
