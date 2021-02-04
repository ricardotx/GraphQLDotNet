using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.ApiRepository;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class UserService : IUserService
	{
		private readonly IApiRepository _repo;

		public UserService(IApiRepository repo)
		{
			_repo = repo;
		}

		public async Task<UserApiModel> CreateAsync(UserApiModel user)
		{
			var dataModel = user.Convert();
			await _repo.User.AddAsync(dataModel);
			await _repo.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<bool> DeleteMultiAsync(Guid[] userIds)
		{
			for (int i = 0; i < userIds.Length; i++)
			{
				await DeleteOneAsync(userIds[i]);
			}

			return true;
		}

		public async Task<string> DeleteOneAsync(Guid userId)
		{
			var dataModel = await _repo.User.GetByIdAsync(userId);
			_repo.User.Remove(dataModel);
			await _repo.SaveChangesAsync();
			return $"The user with the id: '{ userId}' has been successfully deleted from db.";
		}

		public async Task<IEnumerable<UserApiModel>> GetAllAsync()
		{
			var dataModels = await _repo.User.GetAllAsync();
			return dataModels.ConvertAll();
		}

		public async Task<UserApiModel> GetByEmailAsync(string email)
		{
			var dataModel = await _repo.User.FindOneAsync(x => x.Email == email);
			return dataModel.Convert();
		}

		public async Task<UserApiModel> GetByIdAsync(Guid userId)
		{
			var dataModel = await _repo.User.GetByIdAsync(userId);
			return dataModel.Convert();
		}

		public async Task<UserApiModel> UpdateAsync(UserApiModel user)
		{
			var dataModel = await _repo.User.GetByIdAsync(user.Id);
			dataModel.Name = user.Name;
			dataModel.RoleId = user.RoleId;
			dataModel.Status = user.Status;
			dataModel.Password = user.Password;
			await _repo.SaveChangesAsync();
			return dataModel.Convert();
		}
	}
}
