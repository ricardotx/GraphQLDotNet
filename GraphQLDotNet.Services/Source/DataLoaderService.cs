using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.ApiRepository;
using GraphQLDotNet.Core.Source.Extensions;
using GraphQLDotNet.Core.Source.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Services.Source
{
	public class DataLoaderService : IDataLoaderService
	{
		private readonly IApiRepository _repo;

		public DataLoaderService(IApiRepository repo)
		{
			_repo = repo;
		}

		public async Task<ILookup<Guid, AccountApiModel>> AccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds)
		{
			var dataModels = await _repo.Account.FindAllAsync(x => ownerIds.Contains(x.OwnerId));
			return dataModels.ConvertAll().ToLookup(x => x.OwnerId);
		}

		public async Task<IDictionary<Guid, OwnerApiModel>> OwnersByIdAsync(IEnumerable<Guid> ownerIds)
		{
			var dataModels = await _repo.Owner.FindAllAsync(x => ownerIds.Contains(x.Id));
			return dataModels.ConvertAll().ToDictionary(x => x.Id);
		}
	}
}
