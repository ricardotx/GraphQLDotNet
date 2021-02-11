using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery
	{
		protected void SetAccountQueries(IAccountResolver resolvers)
		{
			FieldAsync<ListGraphType<AccountType>>(
			   "accounts",
			   resolve: async context => await resolvers.AccountsAsync()
			);

			FieldAsync<AccountType>(
				"account",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
				resolve: async context => await resolvers.AccountAsync(context)
			);
		}
	}
}
