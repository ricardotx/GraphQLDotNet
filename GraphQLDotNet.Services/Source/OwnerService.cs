using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Core.Source.Storage;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class OwnerService : IOwnerService
	{
		private readonly IStorage storage;

		public OwnerService(IStorage storage)
		{
			this.storage = storage;
		}

		public async Task<OwnerApiModel> CreateOwnerAsync(OwnerApiModel owner)
		{
			var dataModel = owner.Convert();
			await this.storage.Owners.AddAsync(dataModel);
			await this.storage.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteOwnerAsync(Guid ownerId)
		{
			var dbOwner = await this.storage.Owners.GetByIdAsync(ownerId);
			this.storage.Owners.Remove(dbOwner);
			await this.storage.SaveChangesAsync();
			return $"The owner with the id: {ownerId} has been successfully deleted from db.";
		}

		public async Task<OwnerApiModel> GetOwnerAsync(Guid ownerId)
		{
			var owner = await this.storage.Owners.GetByIdAsync(ownerId);
			return owner.Convert();
		}

		public async Task<IEnumerable<OwnerApiModel>> GetOwnersAsync()
		{
			var owners = await this.storage.Owners.GetAllAsync();
			return owners.ConvertAll();
		}

		public async Task<OwnerApiModel> UpdateOwnerAsync(Guid ownerId, OwnerApiModel owner)
		{
			var dbOwner = await this.storage.Owners.GetByIdAsync(ownerId);
			dbOwner.Name = owner.Name;
			dbOwner.Address = owner.Address;
			await this.storage.SaveChangesAsync();
			return dbOwner.Convert();
		}
	}
}
