using GraphQLDotNet.Core.Source.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Contracts.Repositories
{
	public interface IDataLoaderRepository
	{
		Task<ILookup<Guid, Account>> AccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds);

		Task<IDictionary<Guid, Owner>> OwnersByIdAsync(IEnumerable<Guid> ownerIds);
	}
}
