using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Core.Source.Dtos;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class OwnerType : ObjectGraphType<OwnerDto>
	{
		public OwnerType(
			IOwnerResolver resolver,
			IDataLoaderContextAccessor dataLoader
		)
		{
			Name = "Owner";
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the owner object.");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name property from the owner object.");
			Field(x => x.Address, type: typeof(StringGraphType)).Description("Address property from the owner object.");
			Field<ListGraphType<AccountType>>("accounts", resolve: context => resolver.AccountsDataLoader(context, dataLoader));
		}
	}
}
