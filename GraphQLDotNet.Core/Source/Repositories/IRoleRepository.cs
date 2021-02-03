using GraphQLDotNet.Core.Source.DataModels;

namespace GraphQLDotNet.Core.Source.Repositories
{
	public interface IRoleRepository : IBaseRepository<Role>
	{
		// We only need a method that already exists in the BaseRepository
	}
}
