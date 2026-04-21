var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<BookType>();
builder.Services.AddAuthentication();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.Run();
