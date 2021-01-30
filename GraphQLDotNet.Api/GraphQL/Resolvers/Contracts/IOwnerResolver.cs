using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Data.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.GraphQL.Resolvers.Contracts
{
	public interface IOwnerResolver
	{
		IDataLoaderResult<IEnumerable<Account>> DataLoaderAccounts(IResolveFieldContext<Owner> context, IDataLoaderContextAccessor dataLoader);

		Task<Owner> OwnerAsync(IResolveFieldContext context);

		Task<Owner> OwnerCreateAsync(IResolveFieldContext context);

		Task<string> OwnerDeleteAsync(IResolveFieldContext context);

		Task<IEnumerable<Owner>> OwnersAsync();

		Task<Owner> OwnerUpdateAsync(IResolveFieldContext context);
	}
}
