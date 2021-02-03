using GraphQLDotNet.Core.Source.Models;
using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Data.Source.Context;

using System;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source.Repositories
{
	public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
	{
		private readonly ApplicationContext _db;

		public OwnerRepository(ApplicationContext context) : base(context)
		{
			_db = context;
		}

		public override async Task AddAsync(Owner owner)
		{
			owner.Id = Guid.NewGuid();
			await _db.Owners.AddAsync(owner);
		}
	}
}
