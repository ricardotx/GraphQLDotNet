using GraphQL.Types;

using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery : ObjectGraphType
	{
		public RootQuery(
			IOwnerResolver ownerResolver,
			IAccountResolver accountResolver,
			IRoleRepository roleRepo, // TODO: Change this to Resolvers
			IUserRepository userRepo // TODO: Change this to Resolvers
		)
		{
			Name = "Query";
			SetOwnerQueries(ownerResolver);
			SetAccountQueries(accountResolver);
			SetRoleQueries(roleRepo);
			SetUserQueries(userRepo);
		}
	}
}
