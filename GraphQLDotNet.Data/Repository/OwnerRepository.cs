using GraphQLDotNet.Data.Context;
using GraphQLDotNet.Data.Contracts;
using GraphQLDotNet.Data.Entities;

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

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }

        public IEnumerable<Owner> GetAll() => _context.Owners.ToList();

        public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(x => x.Id.Equals(id));

        public async Task<IDictionary<Guid, Owner>> DataLoaderOwnersByIdAsync(IEnumerable<Guid> ownerIds)
        {
            var owners = await _context.Owners.Where(a => ownerIds.Contains(a.Id)).ToListAsync();
            return owners.ToDictionary(x => x.Id);
        }

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            _context.SaveChanges();
            return dbOwner;
        }
    }
}
