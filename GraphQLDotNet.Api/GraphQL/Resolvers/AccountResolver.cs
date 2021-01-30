using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Data.Models;
using GraphQLDotNet.Data.Repository.Contracts;
using GraphQLDotNet.Services.Contracts;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.GraphQL.Resolvers
{
	public class AccountResolver : IAccountResolver
	{
		private readonly IAccountService _accountService;
		private readonly IDataLoaderRepository _dataLoaderRepo;

		public AccountResolver(IAccountService accountService, IDataLoaderRepository dataLoaderRepo)
		{
			_accountService = accountService;
			_dataLoaderRepo = dataLoaderRepo;
		}

		public async Task<Account> AccountAsync(IResolveFieldContext context)
		{
			Guid accountId;

			if (!Guid.TryParse(context.GetArgument<string>(nameof(accountId)), out accountId))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await _accountService.GetAccountAsync(accountId);
		}

		public async Task<Account> AccountCreateAsync(IResolveFieldContext context)
		{
			var owner = context.GetArgument<Account>("data");
			return await _accountService.CreateAccountAsync(owner);
		}

		public async Task<string> AccountDeleteAsync(IResolveFieldContext context)
		{
			var accountId = context.GetArgument<Guid>("accountId");
			return await _accountService.DeleteAccountAsync(accountId);
		}

		public async Task<IEnumerable<Account>> AccountsAsync()
		{
			return await _accountService.GetAccountsAsync();
		}

		public async Task<Account> AccountUpdateAsync(IResolveFieldContext context)
		{
			var account = context.GetArgument<Account>("data");
			var accountId = context.GetArgument<Guid>("accountId");
			return await _accountService.UpdateAccountAsync(accountId, account);
		}

		public IDataLoaderResult<Owner> OwnerAsync(IResolveFieldContext<Account> context, IDataLoaderContextAccessor dataLoader)
		{
			var loader = dataLoader.Context.GetOrAddBatchLoader<Guid, Owner>(nameof(_dataLoaderRepo.OwnersByIdAsync), _dataLoaderRepo.OwnersByIdAsync);
			return loader.LoadAsync(context.Source.OwnerId);
		}
	}
}
