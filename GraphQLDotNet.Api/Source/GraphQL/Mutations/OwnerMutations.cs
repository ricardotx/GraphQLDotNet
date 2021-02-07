using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Mutations
{
	public partial class RootMutation
	{
		protected void SetOwnerMutations(IOwnerResolver resolvers)
		{
			Field<OwnerType>(
				"ownerCreate",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "data" }),
				resolve: context => resolvers.OwnerCreateAsync(context)
			);

			Field<OwnerType>(
				"ownerUpdate",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "data" },
					new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
				resolve: context => resolvers.OwnerUpdateAsync(context)
			);

			Field<StringGraphType>(
				"ownerDelete",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
				resolve: context => resolvers.OwnerDeleteAsync(context)
			);
		}
	}
}
