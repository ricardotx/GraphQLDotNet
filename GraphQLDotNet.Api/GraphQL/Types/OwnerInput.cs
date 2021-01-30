using GraphQL.Types;

namespace GraphQLDotNet.Api.GraphQL.Types
{
	public class OwnerInput : InputObjectGraphType
	{
		public OwnerInput()
		{
			Name = "OwnerInput";
			Field<NonNullGraphType<StringGraphType>>("name");
			Field<StringGraphType>("address");
		}
	}
}
