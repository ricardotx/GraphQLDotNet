using GraphQL;
using GraphQL.DataLoader;

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

		public async Task<AccountApiModel> AccountAsync(IResolveFieldContext context)
		{
			Guid accountId;

			if (!Guid.TryParse(context.GetArgument<string>(nameof(accountId)), out accountId))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await this.accountService.GetAccountAsync(accountId);
		}

		public async Task<AccountApiModel> AccountCreateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<AccountApiModel>("data");
			return await this.accountService.CreateAccountAsync(data);
		}

		public async Task<string> AccountDeleteAsync(IResolveFieldContext context)
		{
			var accountId = context.GetArgument<Guid>("accountId");
			return await this.accountService.DeleteAccountAsync(accountId);
		}

		public async Task<IEnumerable<AccountApiModel>> AccountsAsync()
		{
			return await this.accountService.GetAccountsAsync();
		}

		public async Task<AccountApiModel> AccountUpdateAsync(IResolveFieldContext context)
		{
			var account = context.GetArgument<AccountApiModel>("data");
			var accountId = context.GetArgument<Guid>("accountId");
			return await this.accountService.UpdateAccountAsync(accountId, account);
		}

		public IDataLoaderResult<OwnerApiModel> OwnerAsync(
			IResolveFieldContext<AccountApiModel> context,
			IDataLoaderContextAccessor dataLoader
		)
		{
			var loader = dataLoader.Context
				.GetOrAddBatchLoader<Guid, OwnerApiModel>(nameof(this.dataLoaderService.OwnersByIdAsync),
				this.dataLoaderService.OwnersByIdAsync);

			return loader.LoadAsync(context.Source.OwnerId);
		}
	}
}
