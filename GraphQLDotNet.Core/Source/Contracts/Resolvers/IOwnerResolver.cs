using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Contracts.Resolvers
{
	public interface IOwnerResolver
	{
		IDataLoaderResult<IEnumerable<Account>> AccountsAsync(IResolveFieldContext<Owner> context, IDataLoaderContextAccessor dataLoader);

		Task<Owner> OwnerAsync(IResolveFieldContext context);

		Task<Owner> OwnerCreateAsync(IResolveFieldContext context);

		Task<string> OwnerDeleteAsync(IResolveFieldContext context);

		Task<IEnumerable<Owner>> OwnersAsync();

		Task<Owner> OwnerUpdateAsync(IResolveFieldContext context);
	}
}
