using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types.Enums;
using GraphQLDotNet.Core.Source.Dtos;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class AccountInputType : InputObjectGraphType<AccountDto>
	{
		public AccountInputType()
		{
			Name = "AccountInput";
			Field(x => x.Type, type: typeof(NonNullGraphType<AccountTypeEnumType>));
			Field(x => x.Description, type: typeof(StringGraphType)).Description("Description property from the account object.");
			Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
		}
	}
}
