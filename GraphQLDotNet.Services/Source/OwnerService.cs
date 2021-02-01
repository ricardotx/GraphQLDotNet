using GraphQLDotNet.Core.Source.Contracts.Repositories;
using GraphQLDotNet.Core.Source.Contracts.Services;
using GraphQLDotNet.Core.Source.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class OwnerService : IOwnerService
	{
		private readonly IOwnerRepository _repo;

		public OwnerService(IOwnerRepository repo)
		{
			_repo = repo;
		}

		public async Task<Owner> CreateOwnerAsync(Owner owner) => await _repo.CreateAsync(owner);

		public async Task<string> DeleteOwnerAsync(Guid ownerId)
		{
			var dbOwner = await _repo.GetByIdAsync(ownerId);
			_repo.Delete(dbOwner);
			return $"The owner with the id: {ownerId} has been successfully deleted from db.";
		}

		public async Task<Owner> GetOwnerAsync(Guid ownerId) => await _repo.GetByIdAsync(ownerId);

		public async Task<IEnumerable<Owner>> GetOwnersAsync() => await _repo.GetAllAsync();

		public async Task<Owner> UpdateOwnerAsync(Guid ownerId, Owner owner)
		{
			var dbOwner = await _repo.GetByIdAsync(ownerId);
			return await _repo.UpdateAsync(dbOwner, owner);
		}
	}
}
