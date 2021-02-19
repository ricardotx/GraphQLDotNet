using GraphQLDotNet.Core.Source.Dtos;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Services
{
	public interface IUserService
	{
		// <summary>
		/// Create new user async
		/// </summary>
		Task<UserDto> CreateAsync(UserDto user);

		/// <summary>
		/// Delete multiple users
		/// </summary>
		Task<bool> DeleteAsync(Guid[] userIds);

		/// <summary>
		/// Delete one user
		/// </summary>
		Task<string> DeleteAsync(Guid userId);

		/// <summary>
		/// Get all users
		/// </summary>
		Task<IEnumerable<UserDto>> GetAllAsync();

		/// <summary>
		/// Get user by email
		/// </summary>
		Task<UserDto> GetByEmailAsync(string email);

		/// <summary>
		/// Get user by id
		/// </summary>
		Task<UserDto> GetByIdAsync(Guid userId);

		/// <summary>
		/// Update user
		/// </summary>
		Task<UserDto> UpdateAsync(UserDto user);
	}
}
