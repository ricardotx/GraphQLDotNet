using GraphQLDotNet.Core.Source.Dtos;

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
		Task<RoleDto> CreateAsync(RoleDto role);

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
		Task<IEnumerable<RoleDto>> GetAllAsync();

		/// <summary>
		/// Get role by id
		/// </summary>
		Task<RoleDto> GetByIdAsync(Guid roleId);

		/// <summary>
		/// Update role
		/// </summary>
		Task<RoleDto> UpdateAsync(RoleDto role);
	}
}
