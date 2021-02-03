using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.ApiRepository;
using GraphQLDotNet.Core.Source.Resolvers;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.Source.Resolvers
{
	public class OwnerResolver : IOwnerResolver
	{
		private readonly IDataLoaderService _dataLoaderService;
		private readonly IOwnerService _ownerService;
		private readonly IApiRepository _repo;

		public OwnerResolver(
			IOwnerService ownerService,
			IDataLoaderService dataLoaderService,
			IApiRepository repo
		)
		{
			_ownerService = ownerService;
			_dataLoaderService = dataLoaderService;
			_repo = repo;
		}

		public IDataLoaderResult<IEnumerable<AccountApiModel>> AccountsAsync(
			IResolveFieldContext<OwnerApiModel> context,
			IDataLoaderContextAccessor dataLoader
		)
		{
			var loader = dataLoader.Context
				.GetOrAddCollectionBatchLoader<Guid, AccountApiModel>(nameof(_dataLoaderService.AccountsByOwnerIdsAsync),
				_dataLoaderService.AccountsByOwnerIdsAsync);

			return loader.LoadAsync(context.Source.Id);
		}

		public async Task<OwnerApiModel> OwnerAsync(IResolveFieldContext context)
		{
			Guid ownerId;

			if (!Guid.TryParse(context.GetArgument<string>(nameof(ownerId)), out ownerId))
			{
				context.Errors.Add(new ExecutionError("Wrong value for guid"));
				return null;
			}

			return await _ownerService.GetOwnerAsync(ownerId);
		}

		public async Task<OwnerApiModel> OwnerCreateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<OwnerApiModel>("data");
			return await _ownerService.CreateOwnerAsync(data);
		}

		public async Task<string> OwnerDeleteAsync(IResolveFieldContext context)
		{
			var ownerId = context.GetArgument<Guid>("ownerId");
			return await _ownerService.DeleteOwnerAsync(ownerId);
		}

		public async Task<IEnumerable<OwnerApiModel>> OwnersAsync()
		{
			return await _ownerService.GetOwnersAsync();
		}

		public async Task<OwnerApiModel> OwnerUpdateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<OwnerApiModel>("data");
			var ownerId = context.GetArgument<Guid>("ownerId");
			return await _ownerService.UpdateOwnerAsync(ownerId, data);
		}
	}
}
