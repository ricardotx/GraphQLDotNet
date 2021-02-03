using GraphQLDotNet.Core.Source.DataModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphQLDotNet.Data.Source.Configurations
{
	public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
	{
		private Guid[] _ids;

		public OwnerConfiguration(Guid[] ids)
		{
			_ids = ids;
		}

		public void Configure(EntityTypeBuilder<Owner> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Name)
				.IsRequired();

			// Constraints
			builder
				.HasMany(x => x.Accounts)
				.WithOne(x => x.Owner)
				.HasForeignKey(x => x.OwnerId)
				.OnDelete(DeleteBehavior.SetNull);

			// Seed data
			builder
			  .HasData(
				new Owner
				{
					Id = _ids[0],
					Name = "John Doe",
					Address = "John Doe's address"
				},
				new Owner
				{
					Id = _ids[1],
					Name = "Jane Doe",
					Address = "Jane Doe's address"
				}
			);
		}
	}
}
