using GraphQLDotNet.Core.Source.DataModels;
using GraphQLDotNet.Core.Source.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphQLDotNet.Data.Source.Seeds
{
	class UserSeed : IEntityTypeConfiguration<User>
	{
		private readonly Guid adminRoleId;

		public UserSeed(Guid adminRoleId)
		{
			this.adminRoleId = adminRoleId;
		}

		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
				new User
				{
					Id = Guid.NewGuid(),
					Status = UserStatusEnum.Active,
					Name = "Admin",
					Email = "admin@mail.com",
					Password = "123",
					RoleId = this.adminRoleId,
				}
			);
		}
	}
}
