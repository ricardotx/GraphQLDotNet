using GraphQL.Types;

using GraphQLDotNet.Api.Source.GraphQL.Types.Enums;
using GraphQLDotNet.Core.Source.Entities;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class UserType : ObjectGraphType<User> // TODO. Change this to UserApiModel after creating the resolver
	{
		public UserType()
		{
			Name = "User";
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("User ID");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("User Name");
			Field(x => x.Email, type: typeof(StringGraphType)).Description("User Name");
			Field(x => x.Status, type: typeof(UserStatusEnumType)).Description("User Status");
			Field(x => x.RoleId, type: typeof(IdGraphType)).Description("User Role ID");
			Field<RoleType>("role", resolve: context => null); // TODO. Add DataLoader
		}
	}
}
