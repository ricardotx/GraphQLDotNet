using GraphQL.Types;

namespace GraphQLDotNet.Api.Source.Types
{
	public class AccountInputType : InputObjectGraphType
	{
		public AccountInputType()
		{
			Name = "AccountInput";
			Field<NonNullGraphType<AccountTypeEnumType>>("type");
			Field<NonNullGraphType<StringGraphType>>("description");
			Field<StringGraphType>("ownerId");
		}
	}
}
