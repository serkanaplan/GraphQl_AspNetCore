    using GraphQl_AspNetCore.Abstractions.Services;
    using GraphQl_AspNetCore.Models;
    using GraphQL.Types;

    namespace GraphQl_AspNetCore.Schema.Types
    {
        public class BookType : ObjectGraphType<Book>
        {
            public BookType(IAuthorService authorService)
            {
                Field(x => x.Id).Description("Kitap Kayıt No");
                Field(x => x.Title).Description("Kitap Başlık");
                Field(x => x.AuthorId).Description("Yazar Kayıt No");
                
                // author alanı için alt seçim gereklidir
                Field<AuthorType>("author")
                    .Description("Yazar")
                    .ResolveAsync(async context => await authorService.GetAuthorByIdAsync(context.Source.AuthorId));
            }
        }
    }
