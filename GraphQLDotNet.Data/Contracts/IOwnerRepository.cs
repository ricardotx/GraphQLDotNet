using GraphQLDotNet.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();

        Owner GetById(Guid id);

        Task<IDictionary<Guid, Owner>> DataLoaderOwnersByIdAsync(IEnumerable<Guid> ownerIds);

        Owner CreateOwner(Owner owner);

        Owner UpdateOwner(Owner dbOwner, Owner owner);

        void DeleteOwner(Owner owner);
    }
}
