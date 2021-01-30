using GraphQLDotNet.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Repository.Contracts
{
	public interface IAccountRepository
	{
		Task<Account> CreateAsync(Account account);

		Task<ILookup<Guid, Account>> DataLoaderAccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds);

		void Delete(Account account);

		Task<IEnumerable<Account>> GetAllAsync();

		Task<IEnumerable<Account>> GetAllPerOwnerAsync(Guid ownerId);

		Task<Account> GetByIdAsync(Guid id);

		Task<Account> UpdateAsync(Account dbAccount, Account account);
	}
}
