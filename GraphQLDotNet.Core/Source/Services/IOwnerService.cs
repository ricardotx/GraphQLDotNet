using GraphQLDotNet.Core.Source.Dtos;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Services
{
	public interface IOwnerService
	{
		Task<OwnerDto> CreateOwnerAsync(OwnerDto owner);

		Task<string> DeleteOwnerAsync(Guid ownerId);

		Task<OwnerDto> GetOwnerAsync(Guid ownerId);

		Task<IEnumerable<OwnerDto>> GetOwnersAsync();

		Task<OwnerDto> UpdateOwnerAsync(Guid ownerId, OwnerDto owner);
	}
}
