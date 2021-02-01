using GraphQL.Types;

using GraphQLDotNet.Api.Source.Types;
using GraphQLDotNet.Core.Source.Contracts.Resolvers;

namespace GraphQLDotNet.Api.Source.Queries
{
	public partial class RootQuery
	{
		protected void OwnerQueriesFactory(IOwnerResolver resolver)
		{
			Field<ListGraphType<OwnerType>>(
				"owners",
				resolve: context => resolver.OwnersAsync()
			);

			Field<OwnerType>(
				"owner",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
				resolve: context => resolver.OwnerAsync(context)
			);
		}
	}
}
