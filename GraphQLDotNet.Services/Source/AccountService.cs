using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.DataModels;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class AccountService : IAccountService
	{
		private readonly IRepository _repo;

		public AccountService(IRepository repo)
		{
			_repo = repo;
		}

		public async Task<Account> CreateAccountAsync(Account account)
		{
			await _repo.Account.AddAsync(account);
			await _repo.SaveChangesAsync();
			return account;
		}

		public async Task<string> DeleteAccountAsync(Guid accountId)
		{
			var dbAccount = await _repo.Account.GetByIdAsync(accountId);
			_repo.Account.Remove(dbAccount);
			await _repo.SaveChangesAsync();
			return $"The account with the id: {accountId} has been successfully deleted from db.";
		}

		public async Task<Account> GetAccountAsync(Guid accountId)
		{
			return await _repo.Account.GetByIdAsync(accountId);
		}

		public async Task<IEnumerable<Account>> GetAccountsAsync()
		{
			return await _repo.Account.GetAllAsync();
		}

		public async Task<Account> UpdateAccountAsync(Guid accountId, Account account)
		{
			var dbAccount = await _repo.Account.GetByIdAsync(accountId);
			dbAccount.Description = account.Description;
			dbAccount.Type = account.Type;
			dbAccount.OwnerId = account.OwnerId;
			await _repo.SaveChangesAsync();
			return dbAccount;
		}
	}
}
