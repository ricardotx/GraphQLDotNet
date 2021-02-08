using GraphQL.Types;

using GraphQLDotNet.Core.Source.ApiModels;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class OwnerInputType : InputObjectGraphType<OwnerApiModel>
	{
		public OwnerInputType()
		{
			Name = "OwnerInput";
			Field(x => x.Name, type: typeof(NonNullGraphType<StringGraphType>)).Description("Name property from the owner object.");
			Field(x => x.Address, type: typeof(StringGraphType)).Description("Address property from the owner object.");
		}
	}
}
