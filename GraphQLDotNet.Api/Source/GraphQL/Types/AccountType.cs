using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types.Enums;
using GraphQLDotNet.Core.Source.Dtos;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class AccountType : ObjectGraphType<AccountDto>
	{
		public AccountType(
			IAccountResolver resolver,
			IDataLoaderContextAccessor dataLoader
		)
		{
			Name = "Account";
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the account object.");
			Field(x => x.Description, type: typeof(StringGraphType)).Description("Description property from the account object.");
			Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
			Field(x => x.Type, type: typeof(AccountTypeEnumType));
			Field<OwnerType>("owner", resolve: context => resolver.OwnerDataLoader(context, dataLoader));
		}
	}
}
