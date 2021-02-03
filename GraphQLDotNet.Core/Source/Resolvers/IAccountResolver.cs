using GraphQL;
using GraphQL.DataLoader;

using GraphQLDotNet.Core.Source.ApiModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Core.Source.Resolvers
{
	public interface IAccountResolver
	{
		Task<AccountApiModel> AccountAsync(IResolveFieldContext context);

		Task<AccountApiModel> AccountCreateAsync(IResolveFieldContext context);

		Task<string> AccountDeleteAsync(IResolveFieldContext context);

		Task<IEnumerable<AccountApiModel>> AccountsAsync();

		Task<AccountApiModel> AccountUpdateAsync(IResolveFieldContext context);

		IDataLoaderResult<OwnerApiModel> OwnerAsync(IResolveFieldContext<AccountApiModel> context, IDataLoaderContextAccessor dataLoader);
	}
}
