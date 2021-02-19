using GraphQL.Types;

using GraphQLDotNet.Core.Source.Entities;

namespace GraphQLDotNet.Api.Source.GraphQL.Types
{
	public class RoleType : ObjectGraphType<Role> // TODO. Change this to RoleApiModel after creating the resolver
	{
		public RoleType()
		{
			Name = "Role";
			Field(x => x.Id, type: typeof(NonNullGraphType<IdGraphType>)).Description("Role ID");
			Field(x => x.Name, type: typeof(StringGraphType)).Description("Role Name");
			Field(x => x.Code, type: typeof(StringGraphType)).Description("Role Code");
			Field<ListGraphType<UserType>>("users", resolve: context => null); // TODO. Add DataLoader
		}
	}
}
