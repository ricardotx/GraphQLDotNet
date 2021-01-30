using GraphQLDotNet.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Repository.Contracts
{
	public interface IOwnerRepository
	{
		Task<Owner> CreateAsync(Owner owner);

		Task<IDictionary<Guid, Owner>> DataLoaderOwnersByIdAsync(IEnumerable<Guid> ownerIds);

		void Delete(Owner owner);

		Task<IEnumerable<Owner>> GetAllAsync();

		Task<Owner> GetByIdAsync(Guid id);

		Task<Owner> UpdateAsync(Owner dbOwner, Owner owner);
	}
}
