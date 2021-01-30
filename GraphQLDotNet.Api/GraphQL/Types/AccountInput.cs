using GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Types
{
	public class AccountInput : InputObjectGraphType
	{
		public AccountInput()
		{
			Name = "AccountInput";
			Field<NonNullGraphType<AccountTypeEnum>>("type");
			Field<StringGraphType>("description");
			Field<NonNullGraphType<StringGraphType>>("ownerId");
		}
	}
}
