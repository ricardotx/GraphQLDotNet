using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Contracts;

namespace GraphQLDotNet.Api.GraphQL.Queries
{
    public partial class RootQuery : ObjectGraphType
    {
        public RootQuery(
            IOwnerResolver ownerResolver,
            IAccountResolver accountResolver
        )
        {
            Name = "Query";
            OwnerQueriesFactory(ownerResolver);
            AccountQueriesFactory(accountResolver);
        }
    }
}
