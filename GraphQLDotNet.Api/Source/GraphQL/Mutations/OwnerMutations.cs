using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Mutations
{
	public partial class RootMutation
	{
		protected void SetOwnerMutations(IOwnerResolver resolvers)
		{
			FieldAsync<OwnerType>(
				"ownerCreate",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "data" }),
				resolve: async context => await resolvers.OwnerCreateAsync(context)
			);

			FieldAsync<OwnerType>(
				"ownerUpdate",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "data" },
					new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "ownerId" }),
				resolve: async context => await resolvers.OwnerUpdateAsync(context)
			);

			FieldAsync<StringGraphType>(
				"ownerDelete",
				arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
				resolve: async context => await resolvers.OwnerDeleteAsync(context)
			);
		}
	}
}
