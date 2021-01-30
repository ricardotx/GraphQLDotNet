using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Data.Entities;
using GraphQLDotNet.Data.Repository.Contracts;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.GraphQL.Resolvers
{
	public class AccountResolver : IAccountResolver
	{
		private readonly IOwnerRepository _ownerRepo;
		private readonly IAccountRepository _repo;

		public AccountResolver(IAccountRepository repo, IOwnerRepository ownerRepo)
		{
			_repo = repo;
			_ownerRepo = ownerRepo;
		}

		public async Task<Account> AccountAsync(IResolveFieldContext context)
		{
			Guid id;

			if (!Guid.TryParse(context.GetArgument<string>("accountId"), out id))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await _repo.GetByIdAsync(id);
		}

		public async Task<Account> AccountCreateAsync(IResolveFieldContext context)
		{
			var owner = context.GetArgument<Account>("data");
			return await _repo.CreateAsync(owner);
		}

		public async Task<string> AccountDeleteAsync(IResolveFieldContext context)
		{
			var accountId = context.GetArgument<Guid>("accountId");
			var account = await _repo.GetByIdAsync(accountId);

			if (account == null)
			{
				context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
				return null;
			}

			_repo.Delete(account);
			return $"The account with the id: {accountId} has been successfully deleted from db.";
		}

		public async Task<IEnumerable<Account>> AccountsAsync()
		{
			return await _repo.GetAllAsync();
		}

		public async Task<Account> AccountUpdateAsync(IResolveFieldContext context)
		{
			var account = context.GetArgument<Account>("data");
			var accountId = context.GetArgument<Guid>("accountId");
			var dbAccount = await _repo.GetByIdAsync(accountId);

			if (dbAccount == null)
			{
				context.Errors.Add(new ExecutionError("Couldn't find account in db."));
				return null;
			}

			return await _repo.UpdateAsync(dbAccount, account);
		}

		public IDataLoaderResult<Owner> DataLoaderOwner(IResolveFieldContext<Account> context, IDataLoaderContextAccessor dataLoader)
		{
			var loader = dataLoader.Context.GetOrAddBatchLoader<Guid, Owner>(nameof(_ownerRepo.DataLoaderOwnersByIdAsync), _ownerRepo.DataLoaderOwnersByIdAsync);
			return loader.LoadAsync(context.Source.OwnerId);
		}
	}
}
