using GraphQLDotNet.Core.Source.Contracts;
using GraphQLDotNet.Core.Source.Contracts.Services;
using GraphQLDotNet.Core.Source.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class OwnerService : IOwnerService
	{
		private readonly IRepository _repo;

		public OwnerService(IRepository repo)
		{
			_repo = repo;
		}

		public async Task<Owner> CreateOwnerAsync(Owner owner)
		{
			await _repo.Owner.AddAsync(owner);
			await _repo.SaveChangesAsync();
			return owner;
		}

		public async Task<string> DeleteOwnerAsync(Guid ownerId)
		{
			var dbOwner = await _repo.Owner.GetByIdAsync(ownerId);
			_repo.Owner.Remove(dbOwner);
			await _repo.SaveChangesAsync();
			return $"The owner with the id: {ownerId} has been successfully deleted from db.";
		}

		public async Task<Owner> GetOwnerAsync(Guid ownerId)
		{
			return await _repo.Owner.GetByIdAsync(ownerId);
		}

		public async Task<IEnumerable<Owner>> GetOwnersAsync()
		{
			return await _repo.Owner.GetAllAsync();
		}

		public async Task<Owner> UpdateOwnerAsync(Guid ownerId, Owner owner)
		{
			var dbOwner = await _repo.Owner.GetByIdAsync(ownerId);
			dbOwner.Name = owner.Name;
			dbOwner.Address = owner.Address;
			await _repo.SaveChangesAsync();
			return dbOwner;
		}
	}
}
