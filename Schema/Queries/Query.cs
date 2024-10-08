using GraphQl_AspNetCore.Abstractions.Services;
using GraphQL.Types;
using GraphQL;
using GraphQl_AspNetCore.Schema.Types;

namespace GraphQl_AspNetCore.Schema.Queries;


public class Query : ObjectGraphType<object>
{
    public Query(IAuthorService authorService, IBookService bookService)
    {
        Name = "AuthorsAndBooksQuery";

        Field<ListGraphType<AuthorType>>("authors")
        .ResolveAsync(async context => await authorService.GetAllAuthorsAsync());

        Field<AuthorType>("author")
        .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
        .ResolveAsync(async context => await authorService.GetAuthorByIdAsync(context.GetArgument<int>("id")));

        Field<ListGraphType<BookType>>("books").ResolveAsync(async context => await bookService.GetAllBooksAsync());

        Field<AuthorType>("book")
        .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }))
        .ResolveAsync(async context => await bookService.GetBookByIdAsync(context.GetArgument<int>("id")));
    }
}
