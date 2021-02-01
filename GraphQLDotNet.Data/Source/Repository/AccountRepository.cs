using GraphQLDotNet.Core.Source.Contracts.Repositories;
using GraphQLDotNet.Core.Source.Models;
using GraphQLDotNet.Data.Source.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source.Repository
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
