using GraphQLDotNet.Core.Source.ApiModels;
using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Enums;

using System;

namespace GraphQLDotNet.Core.Source.DataModels
{
	public class User : IConvertModel<User, UserApiModel>
	{
		public string Email { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public Role Role { get; set; }

		public Guid RoleId { get; set; }

		public UserStatusEnum Status { get; set; }

		public UserApiModel Convert()
		{
			return new UserApiModel
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
