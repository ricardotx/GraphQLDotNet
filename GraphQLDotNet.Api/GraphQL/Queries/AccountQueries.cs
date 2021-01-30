using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Api.GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Queries
{
	public partial class RootQuery
	{
		protected void AccountQueriesFactory(IAccountResolver resolvers)
		{
			Field<ListGraphType<AccountType>>(
			   "accounts",
			   resolve: context => resolvers.AccountsAsync()
		   );

			Field<AccountType>(
				"account",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
				resolve: context => resolvers.AccountAsync(context)
			);
		}
	}
}
