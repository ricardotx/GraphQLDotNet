using GraphQLDotNet.Api.Data.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.Data.Contracts
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
