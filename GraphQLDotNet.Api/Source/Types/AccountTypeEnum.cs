using GraphQL.Types;

using GraphQLDotNet.Core.Source.Models;

namespace GraphQLDotNet.Api.Source.Types
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
