using GraphQL.Types;

using GraphQLDotNet.Core.Source.Dtos;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class OwnerInputType : InputObjectGraphType<OwnerDto>
	{
		public OwnerInputType()
		{
			Name = "OwnerInput";
			Field(x => x.Name, type: typeof(NonNullGraphType<StringGraphType>)).Description("Name property from the owner object.");
			Field(x => x.Address, type: typeof(StringGraphType)).Description("Address property from the owner object.");
		}
	}
}
