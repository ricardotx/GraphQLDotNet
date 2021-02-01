using GraphQL.Types;

namespace GraphQLDotNet.Api.Source.Types
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
