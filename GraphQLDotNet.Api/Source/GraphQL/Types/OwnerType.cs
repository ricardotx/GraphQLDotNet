using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Resolvers;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class OwnerType : ObjectGraphType<OwnerApiModel>
	{
		public OwnerType(
			IOwnerResolver resolver,
			IDataLoaderContextAccessor dataLoader
		)
		{
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the owner object.");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name property from the owner object.");
			Field(x => x.Address, type: typeof(StringGraphType)).Description("Address property from the owner object.");
			Field<ListGraphType<AccountType>>("accounts", resolve: context => resolver.AccountsDataLoader(context, dataLoader));
		}
	}
}
