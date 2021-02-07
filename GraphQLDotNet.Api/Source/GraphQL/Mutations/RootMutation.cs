using GraphQL.Types;

using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Mutations
{
	public partial class RootMutation : ObjectGraphType
	{
		public RootMutation(
			IOwnerResolver ownerResolvers,
			IAccountResolver accountResolvers
		 )
		{
			Name = "Mutation";
			SetOwnerMutations(ownerResolvers);
			SetAccountMutations(accountResolvers);
		}
	}
}
