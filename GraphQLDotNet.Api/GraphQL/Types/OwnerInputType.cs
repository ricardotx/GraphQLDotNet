using GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Types
{
    public class OwnerInputType : InputObjectGraphType
    {
        public OwnerInputType()
        {
            Name = "OwnerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");
        }
    }
}
