using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Core.Source.Contracts.Resolvers;
using GraphQLDotNet.Core.Source.Models;

namespace GraphQLDotNet.Api.Source.Types
{
	public class AccountType : ObjectGraphType<Account>
	{
		public AccountType(IAccountResolver resolver, IDataLoaderContextAccessor dataLoader)
		{
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the account object.");
			Field(x => x.Description, type: typeof(StringGraphType)).Description("Description property from the account object.");
			Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
			Field(x => x.Type, type: typeof(AccountTypeEnum));
			Field<OwnerType>("owner", resolve: context => resolver.OwnerAsync(context, dataLoader));
		}
	}
}
