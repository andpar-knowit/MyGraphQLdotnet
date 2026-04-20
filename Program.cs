var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<BookType>();


var app = builder.Build();

app.UseStaticFiles();
app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.Run();
