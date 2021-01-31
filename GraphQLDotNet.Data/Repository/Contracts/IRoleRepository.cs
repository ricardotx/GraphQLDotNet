using GraphQLDotNet.Data.Models;

namespace GraphQLDotNet.Data.Repository.Contracts
{
	public interface IRoleRepository : IRepository<Role>
	{
		// We only need a method that already exists in the BaseRepository
	}
}
