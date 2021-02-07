using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Resolvers;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.Source.GraphQL.Resolvers
{
	public class OwnerResolver : IOwnerResolver
	{
		private readonly IDataLoaderService dataLoaderService;
		private readonly IOwnerService ownerService;

		public OwnerResolver(
			IOwnerService ownerService,
			IDataLoaderService dataLoaderService
		)
		{
			this.ownerService = ownerService;
			this.dataLoaderService = dataLoaderService;
		}

		public IDataLoaderResult<IEnumerable<AccountApiModel>> AccountsAsync(
			IResolveFieldContext<OwnerApiModel> context,
			IDataLoaderContextAccessor dataLoader
		)
		{
			var loader = dataLoader.Context
				.GetOrAddCollectionBatchLoader<Guid, AccountApiModel>(nameof(this.dataLoaderService.AccountsByOwnerIdsAsync),
				this.dataLoaderService.AccountsByOwnerIdsAsync);

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

			return await this.ownerService.GetOwnerAsync(ownerId);
		}

		public async Task<OwnerApiModel> OwnerCreateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<OwnerApiModel>("data");
			return await this.ownerService.CreateOwnerAsync(data);
		}

		public async Task<string> OwnerDeleteAsync(IResolveFieldContext context)
		{
			var ownerId = context.GetArgument<Guid>("ownerId");
			return await this.ownerService.DeleteOwnerAsync(ownerId);
		}

		public async Task<IEnumerable<OwnerApiModel>> OwnersAsync()
		{
			return await this.ownerService.GetOwnersAsync();
		}

		public async Task<OwnerApiModel> OwnerUpdateAsync(IResolveFieldContext context)
		{
			var data = context.GetArgument<OwnerApiModel>("data");
			var ownerId = context.GetArgument<Guid>("ownerId");
			return await this.ownerService.UpdateOwnerAsync(ownerId, data);
		}
	}
}
