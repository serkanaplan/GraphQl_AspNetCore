using GraphQl_AspNetCore.Abstractions.Repositories;
using GraphQl_AspNetCore.Abstractions.Services;
using GraphQl_AspNetCore.Repositories;
using GraphQl_AspNetCore.Services;
using GraphQl_AspNetCore.Schema;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<ISchema, AuthorsSchema>(services => new AuthorsSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddGraphQL(options => options.ConfigureExecution((opt, next) =>
{
    opt.EnableMetrics = true;
    return next(opt);
}).AddSystemTextJson());


var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseGraphQLAltair();

app.UseGraphQL<ISchema>();
app.Run();
