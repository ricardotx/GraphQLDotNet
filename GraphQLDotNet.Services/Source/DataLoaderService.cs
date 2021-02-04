using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;
using GraphQLDotNet.Core.Source.Storage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class DataLoaderService : IDataLoaderService
	{
		private readonly IStorage storage;

		public DataLoaderService(IStorage storage)
		{
			this.storage = storage;
		}

		public async Task<ILookup<Guid, AccountApiModel>> AccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds)
		{
			var dataModels = await this.storage.Accounts.FindAllAsync(x => ownerIds.Contains(x.OwnerId));
			return dataModels.ConvertAll().ToLookup(x => x.OwnerId);
		}

		public async Task<IDictionary<Guid, OwnerApiModel>> OwnersByIdAsync(IEnumerable<Guid> ownerIds)
		{
			var dataModels = await this.storage.Owners.FindAllAsync(x => ownerIds.Contains(x.Id));
			return dataModels.ConvertAll().ToDictionary(x => x.Id);
		}
	}
}
