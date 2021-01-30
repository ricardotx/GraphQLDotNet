using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Data.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Api.GraphQL.Resolvers.Contracts
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
