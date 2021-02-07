using GraphQL.Types;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
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
