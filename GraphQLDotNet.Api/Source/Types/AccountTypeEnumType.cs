using GraphQL.Types;

using GraphQLDotNet.Core.Source.Enums;

namespace GraphQLDotNet.Api.Source.Types
{
	public class AccountTypeEnumType : EnumerationGraphType<AccountTypeEnum>
	{
		public AccountTypeEnumType()
		{
			Name = "AccountTypeEnum";
			Description = "Enumeration for the account type object.";
		}
	}
}
