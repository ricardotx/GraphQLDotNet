using GraphQL.Types;

using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery : ObjectGraphType
	{
		public RootQuery(
			IOwnerResolver ownerResolver,
			IAccountResolver accountResolver
		)
		{
			Name = "Query";
			SetOwnerQueries(ownerResolver);
			SetAccountQueries(accountResolver);
		}
	}
}
