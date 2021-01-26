using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Contracts;
using GraphQLDotNet.Api.GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Queries
{
    public partial class RootQuery
    {
        protected void OwnerQueriesFactory(IOwnerResolver resolver)
        {
            Field<ListGraphType<OwnerType>>(
                "owners",
                resolve: context => resolver.QueryOwners()
            );

            Field<OwnerType>(
                "owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
                resolve: context => resolver.QueryOwner(context)
            );
        }
    }
}
