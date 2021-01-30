using GraphQLDotNet.Data.Context;
using GraphQLDotNet.Data.Entities;
using GraphQLDotNet.Data.Repository.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Repository
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ApplicationContext _context;

		public AccountRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<Account> CreateAsync(Account account)
		{
			account.Id = Guid.NewGuid();
			await _context.AddAsync(account);
			await _context.SaveChangesAsync();
			return account;
		}

		public async Task<ILookup<Guid, Account>> DataLoaderAccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds)
		{
			var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
			return accounts.ToLookup(x => x.OwnerId);
		}

		public void Delete(Account account)
		{
			_context.Remove(account);
			_context.SaveChanges();
		}

		public async Task<IEnumerable<Account>> GetAllAsync() => await _context.Accounts.ToListAsync();

		public async Task<IEnumerable<Account>> GetAllPerOwnerAsync(Guid ownerId) => await _context.Accounts
			.Where(a => a.OwnerId.Equals(ownerId))
			.ToListAsync();

		public async Task<Account> GetByIdAsync(Guid id) => await _context.Accounts.SingleOrDefaultAsync(x => x.Id.Equals(id));

		public async Task<Account> UpdateAsync(Account dbAccount, Account account)
		{
			dbAccount.Description = account.Description;
			dbAccount.Type = account.Type;
			dbAccount.OwnerId = account.OwnerId;
			await _context.SaveChangesAsync();
			return dbAccount;
		}
	}
}
