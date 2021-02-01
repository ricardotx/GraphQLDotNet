using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Core.Source.Contracts.Resolvers;
using GraphQLDotNet.Core.Source.Models;

namespace GraphQLDotNet.Api.Source.Types
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
