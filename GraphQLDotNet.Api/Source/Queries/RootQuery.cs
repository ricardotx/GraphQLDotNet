using GraphQL.Types;

using GraphQLDotNet.Core.Source.Contracts.Resolvers;

namespace GraphQLDotNet.Api.Source.Queries
{
	public partial class RootQuery : ObjectGraphType
	{
		public RootQuery(
			IOwnerResolver ownerResolver,
			IAccountResolver accountResolver
		)
		{
			Name = "Query";
			OwnerQueriesFactory(ownerResolver);
			AccountQueriesFactory(accountResolver);
		}
	}
}
