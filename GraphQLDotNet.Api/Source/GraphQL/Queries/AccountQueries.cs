using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery
	{
		protected void SetAccountQueries(IAccountResolver resolvers)
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
