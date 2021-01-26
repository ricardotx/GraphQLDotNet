using GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Types
{
    public class AccountInputType : InputObjectGraphType
    {
        public AccountInputType()
        {
            Name = "AccountInput";
            Field<NonNullGraphType<AccountTypeEnumType>>("type");
            Field<StringGraphType>("description");
            Field<NonNullGraphType<StringGraphType>>("ownerId");
        }
    }
}
