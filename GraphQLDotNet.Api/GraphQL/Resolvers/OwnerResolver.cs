using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Data.Models;
using GraphQLDotNet.Data.Repository.Contracts;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.GraphQL.Resolvers
{
	public class OwnerResolver : IOwnerResolver
	{
		private readonly IAccountRepository _accountRepo;
		private readonly IOwnerRepository _repo;

		public OwnerResolver(IOwnerRepository repo, IAccountRepository accountRepo)
		{
			_repo = repo;
			_accountRepo = accountRepo;
		}

		public IDataLoaderResult<IEnumerable<Account>> DataLoaderAccounts(IResolveFieldContext<Owner> context, IDataLoaderContextAccessor dataLoader)
		{
			var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>(nameof(_accountRepo.DataLoaderAccountsByOwnerIdsAsync),
				_accountRepo.DataLoaderAccountsByOwnerIdsAsync);

			return loader.LoadAsync(context.Source.Id);
		}

		public async Task<Owner> OwnerAsync(IResolveFieldContext context)
		{
			Guid id;

			if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await _repo.GetByIdAsync(id);
		}

		public async Task<Owner> OwnerCreateAsync(IResolveFieldContext context)
		{
			var owner = context.GetArgument<Owner>("data");
			return await _repo.CreateAsync(owner);
		}

		public async Task<string> OwnerDeleteAsync(IResolveFieldContext context)
		{
			var ownerId = context.GetArgument<Guid>("ownerId");
			var owner = await _repo.GetByIdAsync(ownerId);

			if (owner == null)
			{
				context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
				return null;
			}

			_repo.Delete(owner);
			return $"The owner with the id: {ownerId} has been successfully deleted from db.";
		}

		public async Task<IEnumerable<Owner>> OwnersAsync()
		{
			return await _repo.GetAllAsync();
		}

		public async Task<Owner> OwnerUpdateAsync(IResolveFieldContext context)
		{
			var owner = context.GetArgument<Owner>("data");
			var ownerId = context.GetArgument<Guid>("ownerId");
			var dbOwner = await _repo.GetByIdAsync(ownerId);

			if (dbOwner == null)
			{
				context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
				return null;
			}

			return await _repo.UpdateAsync(dbOwner, owner);
		}
	}
}
