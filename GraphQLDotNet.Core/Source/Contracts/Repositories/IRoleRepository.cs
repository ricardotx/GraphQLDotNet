using GraphQLDotNet.Core.Source.Models;

namespace GraphQLDotNet.Core.Source.Contracts.Repositories
{
	public interface IRoleRepository : IRepository<Role>
	{
		// We only need a method that already exists in the BaseRepository
	}
}
