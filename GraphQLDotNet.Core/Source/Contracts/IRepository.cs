using GraphQLDotNet.Core.Source.Contracts.Repositories;

using System;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Contracts
{
	public interface IRepository : IDisposable
	{
		IAccountRepository Account { get; }
		IDataLoaderRepository DataLoader { get; }
		IOwnerRepository Owner { get; }
		IRoleRepository Role { get; }
		IUserRepository User { get; }

		/// <summary>
		/// Save all changes made to the database
		/// </summary>
		Task<int> SaveChangesAsync();
	}
}
