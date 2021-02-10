using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Mutations
{
	public partial class RootMutation
	{
		protected void SetAccountMutations(IAccountResolver resolvers)
		{
			FieldAsync<AccountType>(
				"accountCreate",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "data" }),
				resolve: async context => await resolvers.AccountCreateAsync(context)
			);

			FieldAsync<AccountType>(
				"accountUpdate",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "data" },
					new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
				resolve: async context => await resolvers.AccountUpdateAsync(context)
			);

			FieldAsync<StringGraphType>(
				"accountDelete",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "accountId" }),
				resolve: async context => await resolvers.AccountDeleteAsync(context)
			);
		}
	}
}
