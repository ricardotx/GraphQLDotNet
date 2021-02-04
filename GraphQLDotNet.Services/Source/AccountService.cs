using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Core.Source.Storage;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class AccountService : IAccountService
	{
		private readonly IStorage storage;

		public AccountService(IStorage storage)
		{
			this.storage = storage;
		}

		public async Task<AccountApiModel> CreateAccountAsync(AccountApiModel account)
		{
			var dataModel = account.Convert();
			await this.storage.Accounts.AddAsync(dataModel);
			await this.storage.SaveChangesAsync();
			return dataModel.Convert();
		}

		public async Task<string> DeleteAccountAsync(Guid accountId)
		{
			var dbAccount = await this.storage.Accounts.GetByIdAsync(accountId);
			this.storage.Accounts.Remove(dbAccount);
			await this.storage.SaveChangesAsync();
			return $"The account with the id: {accountId} has been successfully deleted from db.";
		}

		public async Task<AccountApiModel> GetAccountAsync(Guid accountId)
		{
			var account = await this.storage.Accounts.GetByIdAsync(accountId);
			return account.Convert();
		}

		public async Task<IEnumerable<AccountApiModel>> GetAccountsAsync()
		{
			var accounts = await this.storage.Accounts.GetAllAsync();
			return accounts.ConvertAll();
		}

		public async Task<AccountApiModel> UpdateAccountAsync(Guid accountId, AccountApiModel account)
		{
			var dbAccount = await this.storage.Accounts.GetByIdAsync(accountId);
			dbAccount.Description = account.Description;
			dbAccount.Type = account.Type;
			dbAccount.OwnerId = account.OwnerId;
			await this.storage.SaveChangesAsync();
			return dbAccount.Convert();
		}
	}
}
