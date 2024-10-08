using GraphQl_AspNetCore.Abstractions.Services;
using GraphQl_AspNetCore.Models;
using GraphQL.Types;

namespace GraphQl_AspNetCore.Schema.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(IBookService bookService)
        {
            Field(x => x.Id).Description("Yazar Kayıt No");
            Field(x => x.Name).Description("Yazar Adı");
            Field(x => x.LastName).Description("Yazar Soyadı");

            // Yazarın kitapları alanı
            Field<ListGraphType<BookType>>("books")
                .Description("Yazarın Kitapları")
                .ResolveAsync(async context => await bookService.GetAllBooksByAuthorAsync(context.Source.Id));
        }
    }
}
