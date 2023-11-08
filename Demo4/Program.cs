using Raven.Client.Documents;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

var services=builder.Services;  
var configuration=builder.Configuration;

services.AddGraphQLServer();

var cert= new X509Certificate2("uk-dev.emrgroup.client.certificate.with.password.pfx", "3922FD4111EC2C99571775AAF2959AD");

services.AddSingleton<IDocumentStore>(_ => new DocumentStore
{
    Urls = new[] { "https://a.uk-dev.emrgroup.ravendb.cloud" },
    Database = "india-11",
    Certificate = cert
}.Initialize());


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGraphQL();


app.Run();
