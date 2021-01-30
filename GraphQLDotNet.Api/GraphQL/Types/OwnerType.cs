using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Resolvers.Contracts;
using GraphQLDotNet.Data.Models;

namespace GraphQLDotNet.Api.GraphQL.Types
{
	public class OwnerType : ObjectGraphType<Owner>
	{
		public OwnerType(IOwnerResolver resolver, IDataLoaderContextAccessor dataLoader)
		{
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Id property from the owner object.");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Name property from the owner object.");
			Field(x => x.Address, type: typeof(StringGraphType)).Description("Address property from the owner object.");
			Field<ListGraphType<AccountType>>("accounts", resolve: context => resolver.AccountsAsync(context, dataLoader));
		}
	}
}
