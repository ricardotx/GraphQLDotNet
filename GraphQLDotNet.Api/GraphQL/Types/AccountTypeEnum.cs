using GraphQL.Types;

using GraphQLDotNet.Data.Models;

namespace GraphQLDotNet.Api.GraphQL.Types
{
	public class AccountTypeEnum : EnumerationGraphType<TypeOfAccount>
	{
		public AccountTypeEnum()
		{
			Name = "AccountTypeEnum";
			Description = "Enumeration for the account type object.";
		}
	}
}
