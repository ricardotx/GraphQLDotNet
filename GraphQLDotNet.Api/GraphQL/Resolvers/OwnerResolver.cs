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
	public class OwnerResolver : IOwnerResolver
	{
		private readonly IDataLoaderRepository _dataLoaderRepo;
		private readonly IOwnerService _ownerService;

		public OwnerResolver(IOwnerService ownerService, IDataLoaderRepository dataLoaderRepo)
		{
			_ownerService = ownerService;
			_dataLoaderRepo = dataLoaderRepo;
		}

		public IDataLoaderResult<IEnumerable<Account>> AccountsAsync(IResolveFieldContext<Owner> context, IDataLoaderContextAccessor dataLoader)
		{
			var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>(nameof(_dataLoaderRepo.AccountsByOwnerIdsAsync),
				_dataLoaderRepo.AccountsByOwnerIdsAsync);

			return loader.LoadAsync(context.Source.Id);
		}

		public async Task<Owner> OwnerAsync(IResolveFieldContext context)
		{
			Guid ownerId;

			if (!Guid.TryParse(context.GetArgument<string>(nameof(ownerId)), out ownerId))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await _ownerService.GetOwnerAsync(ownerId);
		}

		public async Task<Owner> OwnerCreateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<Owner>("data");

			var owner = new Owner
			{
				Name = data.Name,
				Address = data.Address
			};

			return await _ownerService.CreateOwnerAsync(owner);
		}

		public async Task<string> OwnerDeleteAsync(IResolveFieldContext context)
		{
			var ownerId = context.GetArgument<Guid>("ownerId");
			return await _ownerService.DeleteOwnerAsync(ownerId);
		}

		public async Task<IEnumerable<Owner>> OwnersAsync()
		{
			return await _ownerService.GetOwnersAsync();
		}

		public async Task<Owner> OwnerUpdateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<Owner>("data");
			var ownerId = context.GetArgument<Guid>("ownerId");

			var owner = new Owner
			{
				Name = data.Name,
				Address = data.Address
			};

			return await _ownerService.UpdateOwnerAsync(ownerId, owner);
		}
	}
}
