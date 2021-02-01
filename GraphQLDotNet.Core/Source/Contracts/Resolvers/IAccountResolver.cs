using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Contracts.Resolvers
{
	public interface IAccountResolver
	{
		Task<Account> AccountAsync(IResolveFieldContext context);

		Task<Account> AccountCreateAsync(IResolveFieldContext context);

		Task<string> AccountDeleteAsync(IResolveFieldContext context);

		Task<IEnumerable<Account>> AccountsAsync();

		Task<Account> AccountUpdateAsync(IResolveFieldContext context);

		IDataLoaderResult<Owner> OwnerAsync(IResolveFieldContext<Account> context, IDataLoaderContextAccessor dataLoader);
	}
}
