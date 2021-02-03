using GraphQLDotNet.Core.Source.Repositories;

using System;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.ApiRepository
{
	public interface IApiRepository : IDisposable
	{
		IAccountRepository Account { get; }
		IOwnerRepository Owner { get; }
		IRoleRepository Role { get; }
		IUserRepository User { get; }

		/// <summary>
		/// Save all changes made to the database
		/// </summary>
		Task<int> SaveChangesAsync();
	}
}
