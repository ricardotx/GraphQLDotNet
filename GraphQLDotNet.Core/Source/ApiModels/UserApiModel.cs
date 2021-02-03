using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.DataModels;
using GraphQLDotNet.Core.Source.Enums;

using System;

namespace GraphQLDotNet.Core.Source.ApiModels
{
	public class UserApiModel : IConvertModel<UserApiModel, User>
	{
		public string Email { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public RoleApiModel Role { get; set; }

		public Guid RoleId { get; set; }

		public UserStatusEnum Status { get; set; }

		public User Convert()
		{
			return new User
			{
				Id = Id,
				Name = Name,
				Email = Email,
				Status = Status,
				RoleId = RoleId
			};
		}
	}
}
