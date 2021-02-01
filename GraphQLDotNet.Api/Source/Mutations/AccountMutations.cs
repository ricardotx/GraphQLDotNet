using GraphQL.Types;

using GraphQLDotNet.Api.Source.Types;
using GraphQLDotNet.Core.Source.Contracts.Resolvers;

namespace GraphQLDotNet.Api.Source.Mutations
{
	public partial class RootMutation
	{
		protected void AccountMutationsFactory(IAccountResolver resolvers)
		{
			Field<AccountType>(
				"accountCreate",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AccountInput>> { Name = "data" }),
				resolve: context => resolvers.AccountCreateAsync(context)
			);

			Field<AccountType>(
				"accountUpdate",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<AccountInput>> { Name = "data" },
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
