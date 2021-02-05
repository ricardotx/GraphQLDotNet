using GraphQLDotNet.Core.Source.DataModels;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDotNet.Data.Source.Configurations
{
	public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
	{
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
		}
	}
}
