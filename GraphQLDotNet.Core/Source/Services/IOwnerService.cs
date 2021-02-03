using GraphQLDotNet.Core.Source.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Services
{
	public interface IOwnerService
	{
		Task<Owner> CreateOwnerAsync(Owner owner);

		Task<string> DeleteOwnerAsync(Guid ownerId);

		Task<Owner> GetOwnerAsync(Guid ownerId);

		Task<IEnumerable<Owner>> GetOwnersAsync();

		Task<Owner> UpdateOwnerAsync(Guid ownerId, Owner owner);
	}
}
