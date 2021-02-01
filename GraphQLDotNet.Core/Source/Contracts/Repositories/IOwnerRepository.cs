using GraphQLDotNet.Core.Source.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Contracts.Repositories
{
	public interface IOwnerRepository
	{
		Task<Owner> CreateAsync(Owner owner);

		void Delete(Owner owner);

		Task<IEnumerable<Owner>> GetAllAsync();

		Task<Owner> GetByIdAsync(Guid id);

		Task<Owner> UpdateAsync(Owner dbOwner, Owner owner);
	}
}
