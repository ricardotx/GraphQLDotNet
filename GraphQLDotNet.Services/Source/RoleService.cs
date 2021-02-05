using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class RoleService : IRoleService
	{
		private readonly IRepository repo;

		public RoleService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task<RoleApiModel> CreateAsync(RoleApiModel role)
		{
			var dataModel = role.Convert();
			await this.repo.Roles.AddAsync(dataModel);
			await this.repo.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<bool> DeleteAsync(Guid[] roleIds)
		{
			for (int i = 0; i < roleIds.Length; i++)
			{
				await DeleteAsync(roleIds[i]);
			}

			return true;
		}

		public async Task<string> DeleteAsync(Guid roleId)
		{
			var dataModel = await this.repo.Roles.GetByIdAsync(roleId);
			this.repo.Roles.Remove(dataModel);
			await this.repo.SaveChangesAsync();
			return $"The role with the id: '{roleId}' has been successfully deleted from db.";
		}

		public async Task<IEnumerable<RoleApiModel>> GetAllAsync()
		{
			var dataModels = await this.repo.Roles.GetAllAsync();
			return dataModels.ConvertAll();
		}

		public async Task<RoleApiModel> GetByIdAsync(Guid roleId)
		{
			var dataModel = await this.repo.Roles.GetByIdAsync(roleId);
			return dataModel.Convert();
		}

		public async Task<RoleApiModel> UpdateAsync(RoleApiModel role)
		{
			var dataModel = await this.repo.Roles.GetByIdAsync(role.Id);
			dataModel.Name = role.Name;
			dataModel.Code = role.Code;
			await this.repo.SaveChangesAsync();
			return dataModel.Convert();
		}
	}
}
