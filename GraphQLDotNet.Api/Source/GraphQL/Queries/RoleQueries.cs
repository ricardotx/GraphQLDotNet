using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Repositories;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery
	{
		protected void SetRoleQueries(IRoleRepository repo) // TODO: Changes this to Resolvers
		{
			FieldAsync<ListGraphType<RoleType>>(
			  "roles",
			  resolve: async context => await repo.GetAllAsync()
			);
		}
	}
}
