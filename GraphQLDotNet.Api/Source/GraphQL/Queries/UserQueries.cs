using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types;
using GraphQLDotNet.Core.Source.Repositories;

namespace GraphQLDotNet.Api.Source.GraphQL.Queries
{
	public partial class RootQuery
	{
		protected void SetUserQueries(IUserRepository repo) // TODO: Changes this to Resolvers
		{
			FieldAsync<ListGraphType<UserType>>(
			   "users",
			   resolve: async context => await repo.GetAllAsync()
			);
		}
	}
}
