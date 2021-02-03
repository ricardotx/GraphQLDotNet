using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;

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

		public async Task<OwnerApiModel> CreateOwnerAsync(OwnerApiModel owner)
		{
			var dataModel = owner.Convert();
			await _repo.Owner.AddAsync(dataModel);
			await _repo.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteOwnerAsync(Guid ownerId)
		{
			var dbOwner = await _repo.Owner.GetByIdAsync(ownerId);
			_repo.Owner.Remove(dbOwner);
			await _repo.SaveChangesAsync();
			return $"The owner with the id: {ownerId} has been successfully deleted from db.";
		}

		public async Task<OwnerApiModel> GetOwnerAsync(Guid ownerId)
		{
			var owner = await _repo.Owner.GetByIdAsync(ownerId);
			return owner.Convert();
		}

		public async Task<IEnumerable<OwnerApiModel>> GetOwnersAsync()
		{
			var owners = await _repo.Owner.GetAllAsync();
			return owners.ConvertAll();
		}

		public async Task<OwnerApiModel> UpdateOwnerAsync(Guid ownerId, OwnerApiModel owner)
		{
			var dbOwner = await _repo.Owner.GetByIdAsync(ownerId);
			dbOwner.Name = owner.Name;
			dbOwner.Address = owner.Address;
			await _repo.SaveChangesAsync();
			return dbOwner.Convert();
		}
	}
}
