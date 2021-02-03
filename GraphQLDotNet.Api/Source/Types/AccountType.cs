using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.Types
{
	public class AccountType : ObjectGraphType<AccountApiModel>
	{
		public AccountType(IAccountResolver resolver, IDataLoaderContextAccessor dataLoader)
		{
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the account object.");
			Field(x => x.Description, type: typeof(StringGraphType)).Description("Description property from the account object.");
			Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
			Field(x => x.Type, type: typeof(AccountTypeEnumType));
			Field<OwnerType>("owner", resolve: context => resolver.OwnerAsync(context, dataLoader));
		}
	}
}
