using GraphQLDotNet.Core.Source.Dtos;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Services
{
	public interface IAccountService
	{
		Task<AccountDto> CreateAccountAsync(AccountDto account);

		Task<string> DeleteAccountAsync(Guid accountId);

		Task<AccountDto> GetAccountAsync(Guid accountId);

		Task<IEnumerable<AccountDto>> GetAccountsAsync();

		Task<AccountDto> UpdateAccountAsync(Guid accountId, AccountDto account);
	}
}
