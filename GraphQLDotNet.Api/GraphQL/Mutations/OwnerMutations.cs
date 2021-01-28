using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Api.GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Mutations
{
    public partial class RootMutation
    {
        protected void OwnerMutationsFactory(IOwnerResolver resolvers)
        {
            Field<OwnerType>(
                "ownerCreate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
                resolve: context => resolvers.MutationOwnerCreate(context)
            );

            Field<OwnerType>(
                "ownerUpdate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
                resolve: context => resolvers.MutationOwnerUpdate(context)
            );

            Field<StringGraphType>(
                "ownerDelete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context => resolvers.MutationOwnerDelete(context)
            );
        }
    }
}
