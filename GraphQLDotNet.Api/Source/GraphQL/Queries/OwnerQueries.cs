using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery
	{
		protected void SetOwnerQueries(IOwnerResolver resolver)
		{
			FieldAsync<ListGraphType<OwnerType>>(
				"owners",
				resolve: async context => await resolver.OwnersAsync()
			);

			FieldAsync<OwnerType>(
				"owner",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
				resolve: async context => await resolver.OwnerAsync(context)
			);
		}
	}
}
