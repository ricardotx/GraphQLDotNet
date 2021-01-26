using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Contracts;

namespace GraphQLDotNet.Api.GraphQL.Mutations
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
