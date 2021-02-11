using GraphQL.Types;

using GraphQLDotNet.Core.Source.Enums;

namespace GraphQLDotNet.Api.Source.GraphQL.Types.Enums
{
	public class UserStatusEnumType : EnumerationGraphType<UserStatusEnum>
	{
		public UserStatusEnumType()
		{
			Name = "UserStatusEnum";
			Description = "Enumeration for the user status.";
		}
	}
}
