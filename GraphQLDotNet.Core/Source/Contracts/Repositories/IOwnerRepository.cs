using GraphQLDotNet.Core.Source.Models;

namespace GraphQLDotNet.Core.Source.Contracts.Repositories
{
	public interface IOwnerRepository : IBaseRepository<Owner>
	{
		// We only need a method that already exists in the BaseRepository
	}
}
