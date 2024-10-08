using GraphQl_AspNetCore.Schema.Queries;

namespace GraphQl_AspNetCore.Schema;

public class AuthorsSchema : GraphQL.Types.Schema
{
    public AuthorsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Description = "Author And Book Schema";
        Query = serviceProvider.GetRequiredService<Query>();
    }
}
