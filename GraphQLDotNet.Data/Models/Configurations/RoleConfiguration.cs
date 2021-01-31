using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphQLDotNet.Data.Models.Configurations
{
	class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		private Guid _adminRoleId;

		public RoleConfiguration(Guid adminRoleId)
		{
			_adminRoleId = adminRoleId;
		}

		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Code)
				.IsRequired();

			// Index
			builder
				.HasIndex(x => x.Code)
				.IsUnique()
				.HasDatabaseName("UniqueCode");

			// Constraints
			builder
				.HasMany(x => x.Users)
				.WithOne(x => x.Role)
				.HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.Restrict);

			// Seed data
			builder.HasData(
			  new Role
			  {
				  Id = _adminRoleId,
				  Name = RoleCodeEnum.Admin.ToString(),
				  Code = RoleCodeEnum.Admin.ToString().ToLower(),
			  },
			  new Role
			  {
				  Id = Guid.NewGuid(),
				  Name = RoleCodeEnum.User.ToString(),
				  Code = RoleCodeEnum.User.ToString().ToLower(),
			  }
			);
		}
	}
}
