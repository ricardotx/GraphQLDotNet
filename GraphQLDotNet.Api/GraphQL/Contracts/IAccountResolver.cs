using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Api.Data.Entities;

using System.Collections.Generic;

namespace GraphQLDotNet.Api.GraphQL.Contracts
{
    public interface IAccountResolver
    {
        IDataLoaderResult<Owner> DataLoaderOwner(IResolveFieldContext<Account> context, IDataLoaderContextAccessor dataLoader);

        Account MutationAccountCreate(IResolveFieldContext context);

        string MutationAccountDelete(IResolveFieldContext context);

        Account MutationAccountUpdate(IResolveFieldContext context);

        Account QueryAccount(IResolveFieldContext context);

        IEnumerable<Account> QueryAccounts();
    }
}
