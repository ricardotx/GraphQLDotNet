using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Data.Entities;

using System.Collections.Generic;

namespace GraphQLDotNet.Api.GraphQL.Resolvers.Contracts
{
    public interface IOwnerResolver
    {
        IDataLoaderResult<IEnumerable<Account>> DataLoaderAccounts(IResolveFieldContext<Owner> context, IDataLoaderContextAccessor dataLoader);

        Owner QueryOwner(IResolveFieldContext context);

        IEnumerable<Owner> QueryOwners();

        Owner MutationOwnerCreate(IResolveFieldContext context);

        Owner MutationOwnerUpdate(IResolveFieldContext context);

        string MutationOwnerDelete(IResolveFieldContext context);
    }
}
