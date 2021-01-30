using GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Types
{
	public class AccountInput : InputObjectGraphType
	{
		public AccountInput()
		{
			Name = "AccountInput";
			Field<NonNullGraphType<AccountTypeEnum>>("type");
			Field<NonNullGraphType<StringGraphType>>("description");
			Field<StringGraphType>("ownerId");
		}
	}
}
