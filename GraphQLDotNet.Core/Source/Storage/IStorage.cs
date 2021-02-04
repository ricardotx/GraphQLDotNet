using GraphQLDotNet.Core.Source.Repositories;

using System;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Storage
{
	public interface IStorage : IDisposable
	{
		IAccountRepository Accounts { get; }
		IOwnerRepository Owners { get; }
		IRoleRepository Roles { get; }
		IUserRepository Users { get; }

		/// <summary>
		/// Save all changes made to the database
		/// </summary>
		Task<int> SaveChangesAsync();
	}
}
