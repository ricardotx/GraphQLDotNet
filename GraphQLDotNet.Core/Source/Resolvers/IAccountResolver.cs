using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Resolvers
{
	public interface IAccountResolver
	{
		Task<AccountDto> AccountAsync(IResolveFieldContext context);

		Task<AccountDto> AccountCreateAsync(IResolveFieldContext context);

		Task<string> AccountDeleteAsync(IResolveFieldContext context);

		Task<IEnumerable<AccountDto>> AccountsAsync();

		Task<AccountDto> AccountUpdateAsync(IResolveFieldContext context);

		IDataLoaderResult<OwnerDto> OwnerDataLoader(IResolveFieldContext<AccountDto> context, IDataLoaderContextAccessor dataLoader);
	}
}
