using GraphQL.Types;

using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.Mutations
{
	public partial class RootMutation : ObjectGraphType
	{
		public RootMutation(
			IOwnerResolver ownerResolvers,
			IAccountResolver accountResolvers
		 )
		{
			Name = "Mutation";
			OwnerMutationsFactory(ownerResolvers);
			AccountMutationsFactory(accountResolvers);
		}
	}
}
