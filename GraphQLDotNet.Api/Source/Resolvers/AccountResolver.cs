using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.DataModels;
using GraphQLDotNet.Core.Source.Resolvers;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.Source.Resolvers
{
	public class AccountResolver : IAccountResolver
	{
		private readonly IAccountService _accountService;
		private readonly IRepository _repo;

		public AccountResolver(IAccountService accountService, IRepository repo)
		{
			_accountService = accountService;
			_repo = repo;
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
			var data = context.GetArgument<Account>("data");
			var account = new Account()
			{
				Description = data.Description,
				Type = data.Type,
				OwnerId = data.OwnerId,
			};
			return await _accountService.CreateAccountAsync(account);
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
			var loader = dataLoader.Context.GetOrAddBatchLoader<Guid, Owner>(nameof(_repo.DataLoader.OwnersByIdAsync), _repo.DataLoader.OwnersByIdAsync);
			return loader.LoadAsync(context.Source.OwnerId);
		}
	}
}
