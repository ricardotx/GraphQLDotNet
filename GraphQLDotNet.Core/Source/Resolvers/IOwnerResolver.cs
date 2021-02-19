using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.Dtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Resolvers
{
	public interface IOwnerResolver
	{
		IDataLoaderResult<IEnumerable<AccountDto>> AccountsDataLoader(IResolveFieldContext<OwnerDto> context, IDataLoaderContextAccessor dataLoader);

		Task<OwnerDto> OwnerAsync(IResolveFieldContext context);

		Task<OwnerDto> OwnerCreateAsync(IResolveFieldContext context);

		Task<string> OwnerDeleteAsync(IResolveFieldContext context);

		Task<IEnumerable<OwnerDto>> OwnersAsync();

		Task<OwnerDto> OwnerUpdateAsync(IResolveFieldContext context);
	}
}
