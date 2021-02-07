using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Mutations
{
	public partial class RootMutation
	{
		protected void SetAccountMutations(IAccountResolver resolvers)
		{
			Field<AccountType>(
				"accountCreate",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "data" }),
				resolve: context => resolvers.AccountCreateAsync(context)
			);

			Field<AccountType>(
				"accountUpdate",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<AccountInputType>> { Name = "data" },
					new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accountId" }),
				resolve: context => resolvers.AccountUpdateAsync(context)
			);

			Field<StringGraphType>(
				"accountDelete",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "accountId" }),
				resolve: context => resolvers.AccountDeleteAsync(context)
			);
		}
	}
}
