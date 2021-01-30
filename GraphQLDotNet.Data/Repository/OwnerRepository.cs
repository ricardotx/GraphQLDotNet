using GraphQLDotNet.Data.Context;
using GraphQLDotNet.Data.Entities;
using GraphQLDotNet.Data.Repository.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Repository
{
	public class OwnerRepository : IOwnerRepository
	{
		private readonly ApplicationContext _context;

		public OwnerRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<Owner> CreateAsync(Owner owner)
		{
			owner.Id = Guid.NewGuid();
			await _context.AddAsync(owner);
			await _context.SaveChangesAsync();
			return owner;
		}

		public async Task<IDictionary<Guid, Owner>> DataLoaderOwnersByIdAsync(IEnumerable<Guid> ownerIds)
		{
			var owners = await _context.Owners.Where(a => ownerIds.Contains(a.Id)).ToListAsync();
			return owners.ToDictionary(x => x.Id);
		}

		public void Delete(Owner owner)
		{
			_context.Remove(owner);
			_context.SaveChanges();
		}

		public async Task<IEnumerable<Owner>> GetAllAsync() => await _context.Owners.ToListAsync();

		public async Task<Owner> GetByIdAsync(Guid id) => await _context.Owners.SingleOrDefaultAsync(x => x.Id.Equals(id));

		public async Task<Owner> UpdateAsync(Owner dbOwner, Owner owner)
		{
			dbOwner.Name = owner.Name;
			dbOwner.Address = owner.Address;
			await _context.SaveChangesAsync();
			return dbOwner;
		}
	}
}
