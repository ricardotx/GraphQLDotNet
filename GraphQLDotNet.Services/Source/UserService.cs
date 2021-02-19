using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.Dtos;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class UserService : IUserService
	{
		private readonly IRepository repo;

		public UserService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task<UserDto> CreateAsync(UserDto user)
		{
			var dataModel = user.Convert();
			await this.repo.Users.AddAsync(dataModel);
			await this.repo.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteAsync(Guid userId)
		{
			var dataModel = await this.repo.Users.GetByIdAsync(userId);
			this.repo.Users.Remove(dataModel);
			await this.repo.SaveChangesAsync();
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

		public async Task<IEnumerable<UserDto>> GetAllAsync()
		{
			var dataModels = await this.repo.Users.GetAllAsync();
			return dataModels.ConvertAll();
		}

		public async Task<UserDto> GetByEmailAsync(string email)
		{
			var dataModel = await this.repo.Users.FindOneAsync(x => x.Email == email);
			return dataModel.Convert();
		}

		public async Task<UserDto> GetByIdAsync(Guid userId)
		{
			var dataModel = await this.repo.Users.GetByIdAsync(userId);
			return dataModel.Convert();
		}

		public async Task<UserDto> UpdateAsync(UserDto user)
		{
			var dataModel = await this.repo.Users.GetByIdAsync(user.Id);
			dataModel.Name = user.Name;
			dataModel.RoleId = user.RoleId;
			dataModel.Status = user.Status;
			dataModel.Password = user.Password;
			await this.repo.SaveChangesAsync();
			return dataModel.Convert();
		}
	}
}
