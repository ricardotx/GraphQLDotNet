using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery
	{
		protected void SetOwnerQueries(IOwnerResolver resolver)
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