using GraphQLDotNet.Data.Models;
using GraphQLDotNet.Data.Repository.Contracts;
using GraphQLDotNet.Services.Contracts;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _repo;

		public AccountService(IAccountRepository repo)
		{
			_repo = repo;
		}

		public async Task<Account> CreateAccountAsync(Account account) => await _repo.CreateAsync(account);

		public async Task<string> DeleteAccountAsync(Guid accountId)
		{
			var dbAccount = await _repo.GetByIdAsync(accountId);
			_repo.Delete(dbAccount);
			return $"The account with the id: {accountId} has been successfully deleted from db.";
		}

		public async Task<Account> GetAccountAsync(Guid accountId) => await _repo.GetByIdAsync(accountId);

		public async Task<IEnumerable<Account>> GetAccountsAsync() => await _repo.GetAllAsync();

		public async Task<Account> UpdateAccountAsync(Guid accountId, Account account)
		{
			var dbAccount = await _repo.GetByIdAsync(accountId);
			return await _repo.UpdateAsync(dbAccount, account);
		}
	}
}
