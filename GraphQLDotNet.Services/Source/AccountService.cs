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
		private readonly IRepository repo;

		public AccountService(IRepository repo)
		{
			this.repo = repo;
		}

		public async Task<AccountApiModel> CreateAccountAsync(AccountApiModel account)
		{
			var dataModel = account.Convert();
			await this.repo.Accounts.AddAsync(dataModel);
			await this.repo.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteAccountAsync(Guid accountId)
		{
			var dbAccount = await this.repo.Accounts.GetByIdAsync(accountId);
			this.repo.Accounts.Remove(dbAccount);
			await this.repo.SaveChangesAsync();
			return $"The account with the id: {accountId} has been successfully deleted from db.";
		}

		public async Task<AccountApiModel> GetAccountAsync(Guid accountId)
		{
			var account = await this.repo.Accounts.GetByIdAsync(accountId);
			return account.Convert();
		}

		public async Task<IEnumerable<AccountApiModel>> GetAccountsAsync()
		{
			var accounts = await this.repo.Accounts.GetAllAsync();
			return accounts.ConvertAll();
		}

		public async Task<AccountApiModel> UpdateAccountAsync(Guid accountId, AccountApiModel account)
		{
			var dbAccount = await this.repo.Accounts.GetByIdAsync(accountId);
			dbAccount.Description = account.Description;
			dbAccount.Type = account.Type;
			dbAccount.OwnerId = account.OwnerId;
			await this.repo.SaveChangesAsync();
			return dbAccount.Convert();
		}
	}
}
