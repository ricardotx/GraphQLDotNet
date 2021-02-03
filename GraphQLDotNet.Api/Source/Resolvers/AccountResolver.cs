using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source;
using GraphQLDotNet.Core.Source.ApiModels;
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

		public async Task<AccountApiModel> AccountAsync(IResolveFieldContext context)
		{
			Guid accountId;

			if (!Guid.TryParse(context.GetArgument<string>(nameof(accountId)), out accountId))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await _accountService.GetAccountAsync(accountId);
		}

		public async Task<AccountApiModel> AccountCreateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<AccountApiModel>("data");
			return await _accountService.CreateAccountAsync(data);
		}

		public async Task<string> AccountDeleteAsync(IResolveFieldContext context)
		{
			var accountId = context.GetArgument<Guid>("accountId");
			return await _accountService.DeleteAccountAsync(accountId);
		}

		public async Task<IEnumerable<AccountApiModel>> AccountsAsync()
		{
			return await _accountService.GetAccountsAsync();
		}

		public async Task<AccountApiModel> AccountUpdateAsync(IResolveFieldContext context)
		{
			var account = context.GetArgument<AccountApiModel>("data");
			var accountId = context.GetArgument<Guid>("accountId");
			return await _accountService.UpdateAccountAsync(accountId, account);
		}

		public IDataLoaderResult<OwnerApiModel> OwnerAsync(IResolveFieldContext<AccountApiModel> context, IDataLoaderContextAccessor dataLoader)
		{
			var loader = dataLoader.Context.GetOrAddBatchLoader<Guid, OwnerApiModel>(nameof(_repo.DataLoader.OwnersByIdAsync), _repo.DataLoader.OwnersByIdAsync);
			return loader.LoadAsync(context.Source.OwnerId);
		}
	}
}
