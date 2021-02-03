using GraphQLDotNet.Core.Source.ApiModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Services
{
	public interface IOwnerService
	{
		Task<OwnerApiModel> CreateOwnerAsync(OwnerApiModel owner);

		Task<string> DeleteOwnerAsync(Guid ownerId);

		Task<OwnerApiModel> GetOwnerAsync(Guid ownerId);

		Task<IEnumerable<OwnerApiModel>> GetOwnersAsync();

		Task<OwnerApiModel> UpdateOwnerAsync(Guid ownerId, OwnerApiModel owner);
	}
}
