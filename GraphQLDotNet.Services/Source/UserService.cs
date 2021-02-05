using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Core.Source.Storage;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class UserService : IUserService
	{
		private readonly IStorage storage;

		public UserService(IStorage storage)
		{
			this.storage = storage;
		}

		public async Task<UserApiModel> CreateAsync(UserApiModel user)
		{
			var dataModel = user.Convert();
			await this.storage.Users.AddAsync(dataModel);
			await this.storage.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteAsync(Guid userId)
		{
			var dataModel = await this.storage.Users.GetByIdAsync(userId);
			this.storage.Users.Remove(dataModel);
			await this.storage.SaveChangesAsync();
			return $"The user with the id: '{ userId}' has been successfully deleted from db.";
		}

		public async Task<bool> DeleteAsync(Guid[] userIds)
		{
			for (int i = 0; i < userIds.Length; i++)
			{
				await DeleteAsync(userIds[i]);
			}

			return true;
		}

		public async Task<IEnumerable<UserApiModel>> GetAllAsync()
		{
			var dataModels = await this.storage.Users.GetAllAsync();
			return dataModels.ConvertAll();
		}

		public async Task<UserApiModel> GetByEmailAsync(string email)
		{
			var dataModel = await this.storage.Users.FindOneAsync(x => x.Email == email);
			return dataModel.Convert();
		}

		public async Task<UserApiModel> GetByIdAsync(Guid userId)
		{
			var dataModel = await this.storage.Users.GetByIdAsync(userId);
			return dataModel.Convert();
		}

		public async Task<UserApiModel> UpdateAsync(UserApiModel user)
		{
			var dataModel = await this.storage.Users.GetByIdAsync(user.Id);
			dataModel.Name = user.Name;
			dataModel.RoleId = user.RoleId;
			dataModel.Status = user.Status;
			dataModel.Password = user.Password;
			await this.storage.SaveChangesAsync();
			return dataModel.Convert();
		}
	}
}
