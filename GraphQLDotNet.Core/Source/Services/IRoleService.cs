using GraphQLDotNet.Core.Source.ApiModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Services
{
	public interface IRoleService
	{
		// <summary>
		/// Create new user async
		/// </summary>
		Task<RoleApiModel> CreateAsync(RoleApiModel role);

		/// <summary>
		/// Delete multiple roles
		/// </summary>
		Task<bool> DeleteAsync(Guid[] roleIds);

		/// <summary>
		/// Delete one role
		/// </summary>
		Task<string> DeleteAsync(Guid roleId);

		/// <summary>
		/// Get all roles
		/// </summary>
		Task<IEnumerable<RoleApiModel>> GetAllAsync();

		/// <summary>
		/// Get role by id
		/// </summary>
		Task<RoleApiModel> GetByIdAsync(Guid roleId);

		/// <summary>
		/// Update role
		/// </summary>
		Task<RoleApiModel> UpdateAsync(RoleApiModel role);
	}
}
