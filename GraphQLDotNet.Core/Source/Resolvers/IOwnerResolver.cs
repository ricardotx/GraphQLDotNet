using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.ApiModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Resolvers
{
	public interface IOwnerResolver
	{
		IDataLoaderResult<IEnumerable<AccountApiModel>> AccountsDataLoader(IResolveFieldContext<OwnerApiModel> context, IDataLoaderContextAccessor dataLoader);

		Task<OwnerApiModel> OwnerAsync(IResolveFieldContext context);

		Task<OwnerApiModel> OwnerCreateAsync(IResolveFieldContext context);

		Task<string> OwnerDeleteAsync(IResolveFieldContext context);

		Task<IEnumerable<OwnerApiModel>> OwnersAsync();

		Task<OwnerApiModel> OwnerUpdateAsync(IResolveFieldContext context);
	}
}
