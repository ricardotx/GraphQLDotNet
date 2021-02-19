using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.Dtos;
using GraphQLDotNet.Core.Source.Resolvers;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.Source.GraphQL.Resolvers
{
	public class AccountResolver : IAccountResolver
	{
		private readonly IAccountService accountService;
		private readonly IDataLoaderService dataLoaderService;

		public AccountResolver(
			IAccountService accountService,
			IDataLoaderService dataLoaderService
		)
		{
			this.accountService = accountService;
			this.dataLoaderService = dataLoaderService;
		}

		public async Task<AccountDto> AccountAsync(IResolveFieldContext context)
		{
			Guid accountId;

			if (!Guid.TryParse(context.GetArgument<string>(nameof(accountId)), out accountId))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await this.accountService.GetAccountAsync(accountId);
		}

		public async Task<AccountDto> AccountCreateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<AccountDto>("data");
			return await this.accountService.CreateAccountAsync(data);
		}

		public async Task<string> AccountDeleteAsync(IResolveFieldContext context)
		{
			var accountId = context.GetArgument<Guid>("accountId");
			return await this.accountService.DeleteAccountAsync(accountId);
		}

		public async Task<IEnumerable<AccountDto>> AccountsAsync()
		{
			return await this.accountService.GetAccountsAsync();
		}

		public async Task<AccountDto> AccountUpdateAsync(IResolveFieldContext context)
		{
			var account = context.GetArgument<AccountDto>("data");
			var accountId = context.GetArgument<Guid>("accountId");
			return await this.accountService.UpdateAccountAsync(accountId, account);
		}

		public IDataLoaderResult<OwnerDto> OwnerDataLoader(
			IResolveFieldContext<AccountDto> context,
			IDataLoaderContextAccessor dataLoader
		)
		{
			var loader = dataLoader.Context
				.GetOrAddBatchLoader<Guid, OwnerDto>(nameof(this.dataLoaderService.OwnersByIdAsync),
				this.dataLoaderService.OwnersByIdAsync);

			return loader.LoadAsync(context.Source.OwnerId);
		}
	}
}
