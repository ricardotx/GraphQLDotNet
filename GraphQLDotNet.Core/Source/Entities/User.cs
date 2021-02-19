using GraphQLDotNet.Core.Source.Converters;
using GraphQLDotNet.Core.Source.Dtos;
using GraphQLDotNet.Core.Source.Enums;

using System;

namespace GraphQLDotNet.Core.Source.Entities
{
	public class User : IConvertModel<User, UserDto>
	{
		public string Email { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Password { get; set; }

		public Role Role { get; set; }

		public Guid RoleId { get; set; }

		public UserStatusEnum Status { get; set; }

		public UserDto Convert()
		{
			return new UserDto
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
