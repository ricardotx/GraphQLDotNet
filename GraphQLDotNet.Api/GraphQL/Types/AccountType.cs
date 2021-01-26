using GraphQL.DataLoader;
using GraphQL.Types;

using GraphQLDotNet.Api.GraphQL.Contracts;
using GraphQLDotNet.Data.Entities;

namespace GraphQLDotNet.Api.GraphQL.Types
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType(IAccountResolver resolver, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(x => x.Description).Description("Description property from the account object.");
            Field(x => x.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field(x => x.Type, type: typeof(AccountTypeEnumType));
            Field<OwnerType>("owner", resolve: context => resolver.DataLoaderOwner(context, dataLoader));
        }
    }
}
