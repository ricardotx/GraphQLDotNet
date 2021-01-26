using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Contracts;
using GraphQLDotNet.Api.GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Queries
{
    public partial class RootQuery
    {
        protected void AccountQueriesFactory(IAccountResolver resolvers)
        {
            Field<ListGraphType<AccountType>>(
               "accounts",
               resolve: context => resolvers.QueryAccounts()
           );

            Field<AccountType>(
                "account",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
                resolve: context => resolvers.QueryAccount(context)
            );
        }
    }
}
