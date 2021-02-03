using GraphQLDotNet.Core.Source.ApiModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Services
{
	public interface IAccountService
	{
		Task<AccountApiModel> CreateAccountAsync(AccountApiModel account);

		Task<string> DeleteAccountAsync(Guid accountId);

		Task<AccountApiModel> GetAccountAsync(Guid accountId);

		Task<IEnumerable<AccountApiModel>> GetAccountsAsync();

		Task<AccountApiModel> UpdateAccountAsync(Guid accountId, AccountApiModel account);
	}
}
