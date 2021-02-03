using GraphQL.Types;

namespace GraphQLDotNet.Api.Source.Types
{
	public class OwnerInputType : InputObjectGraphType
	{
		public OwnerInputType()
		{
			Name = "OwnerInput";
			Field<NonNullGraphType<StringGraphType>>("name");
			Field<StringGraphType>("address");
		}
	}
}
