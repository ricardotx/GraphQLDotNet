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
		private readonly IRepository repo;

		public OwnerService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task<OwnerApiModel> CreateOwnerAsync(OwnerApiModel owner)
		{
			var dataModel = owner.Convert();
			await this.repo.Owners.AddAsync(dataModel);
			await this.repo.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteOwnerAsync(Guid ownerId)
		{
			var dbOwner = await this.repo.Owners.GetByIdAsync(ownerId);
			this.repo.Owners.Remove(dbOwner);
			await this.repo.SaveChangesAsync();
			return $"The owner with the id: {ownerId} has been successfully deleted from db.";
		}

		public async Task<OwnerApiModel> GetOwnerAsync(Guid ownerId)
		{
			var owner = await this.repo.Owners.GetByIdAsync(ownerId);
			return owner.Convert();
		}

		public async Task<IEnumerable<OwnerApiModel>> GetOwnersAsync()
		{
			var owners = await this.repo.Owners.GetAllAsync();
			return owners.ConvertAll();
		}

		public async Task<OwnerApiModel> UpdateOwnerAsync(Guid ownerId, OwnerApiModel owner)
		{
			var dbOwner = await this.repo.Owners.GetByIdAsync(ownerId);
			dbOwner.Name = owner.Name;
			dbOwner.Address = owner.Address;
			await this.repo.SaveChangesAsync();
			return dbOwner.Convert();
		}
	}
}
