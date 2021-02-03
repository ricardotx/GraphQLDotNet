using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Extensions;
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

		public async Task<AccountApiModel> CreateAccountAsync(AccountApiModel account)
		{
			var dataModel = account.Convert();
			await _repo.Account.AddAsync(dataModel);
			await _repo.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteAccountAsync(Guid accountId)
		{
			var dbAccount = await _repo.Account.GetByIdAsync(accountId);
			_repo.Account.Remove(dbAccount);
			await _repo.SaveChangesAsync();
			return $"The account with the id: {accountId} has been successfully deleted from db.";
		}

		public async Task<AccountApiModel> GetAccountAsync(Guid accountId)
		{
			var account = await _repo.Account.GetByIdAsync(accountId);
			return account.Convert();
		}

		public async Task<IEnumerable<AccountApiModel>> GetAccountsAsync()
		{
			var accounts = await _repo.Account.GetAllAsync();
			return accounts.ConvertAll();
		}

		public async Task<AccountApiModel> UpdateAccountAsync(Guid accountId, AccountApiModel account)
		{
			var dbAccount = await _repo.Account.GetByIdAsync(accountId);
			dbAccount.Description = account.Description;
			dbAccount.Type = account.Type;
			dbAccount.OwnerId = account.OwnerId;
			await _repo.SaveChangesAsync();
			return dbAccount.Convert();
		}
	}
}
