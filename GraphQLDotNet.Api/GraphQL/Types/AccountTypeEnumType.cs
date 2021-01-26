using GraphQL.Types;

using GraphQLDotNet.Api.Data.Entities;

namespace GraphQLDotNet.Api.GraphQL.Types
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "AccountTypeEnumType";
            Description = "Enumeration for the account type object.";
        }
    }
}
