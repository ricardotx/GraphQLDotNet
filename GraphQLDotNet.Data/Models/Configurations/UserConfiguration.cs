using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphQLDotNet.Data.Models.Configurations
{
	class UserConfiguration : IEntityTypeConfiguration<User>
	{
		private Guid _adminRoleId;

		public UserConfiguration(Guid adminRoleId)
		{
			_adminRoleId = adminRoleId;
		}

		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder
			   .HasKey(x => x.Id);

			builder
				.Property(x => x.Status)
				.HasDefaultValue(UserStatusEnum.Active);

			builder
				.Property(x => x.Name)
				.IsRequired();

			builder
				.Property(x => x.Email)
				.IsRequired();

			builder
				.Property(x => x.Password)
				.IsRequired();

			builder
			   .Property(x => x.RoleId)
			   .IsRequired();

			// Index
			builder
				.HasIndex(x => x.Email)
				.IsUnique()
				.HasDatabaseName("UniqueUserEmail");

			// Seed data
			builder
			  .HasData(
				new User
				{
					Id = Guid.NewGuid(),
					Status = UserStatusEnum.Active,
					Name = "Admin",
					Email = "admin@mail.com",
					Password = "123",
					RoleId = _adminRoleId,
				}
			);
		}
	}
}
