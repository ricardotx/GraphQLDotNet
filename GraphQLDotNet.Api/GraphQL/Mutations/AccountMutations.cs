using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Api.GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Mutations
{
    public partial class RootMutation
    {
        protected void AccountMutationsFactory(IAccountResolver resolvers)
        {
            Field<AccountType>(
                "accountCreate",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "account" }),
                resolve: context => resolvers.MutationAccountCreate(context)
            );

            Field<AccountType>(
                "accountUpdate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "account" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
                resolve: context => resolvers.MutationAccountUpdate(context)
            );

            Field<StringGraphType>(
                "accountDelete",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "accountId" }),
                resolve: context => resolvers.MutationAccountDelete(context)
            );
        }
    }
}
