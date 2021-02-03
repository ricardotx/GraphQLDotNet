using GraphQLDotNet.Core.Source.Models;
using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Data.Source.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source.Repositories
{
	public class DataLoaderRepository : IDataLoaderRepository
	{
		private readonly ApplicationContext _context;

		public DataLoaderRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<ILookup<Guid, Account>> AccountsByOwnerIdsAsync(IEnumerable<Guid> ownerIds)
		{
			var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
			return accounts.ToLookup(x => x.OwnerId);
		}

		public async Task<IDictionary<Guid, Owner>> OwnersByIdAsync(IEnumerable<Guid> ownerIds)
		{
			var owners = await _context.Owners.Where(a => ownerIds.Contains(a.Id)).ToListAsync();
			return owners.ToDictionary(x => x.Id);
		}
	}
}
