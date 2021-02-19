using GraphQLDotNet.Core.Source.Entities;

namespace GraphQLDotNet.Core.Source.Repositories
{
	public interface IOwnerRepository : IBaseRepository<Owner>
	{
		// We only need a method that already exists in the BaseRepository
	}
}
