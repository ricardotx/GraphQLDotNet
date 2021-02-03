using GraphQLDotNet.Core.Source.Enums;
using GraphQLDotNet.Core.Source.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;

namespace GraphQLDotNet.Data.Source.Configurations
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		private Guid[] _ids;

		public AccountConfiguration(Guid[] ids)
		{
			_ids = ids;
		}

		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder
				.HasData(
				new Account
				{
					Id = Guid.NewGuid(),
					Type = AccountTypeEnum.Cash,
					Description = "Cash account for our users",
					OwnerId = _ids[0]
				},
				new Account
				{
					Id = Guid.NewGuid(),
					Type = AccountTypeEnum.Savings,
					Description = "Savings account for our users",
					OwnerId = _ids[1]
				},
				new Account
				{
					Id = Guid.NewGuid(),
					Type = AccountTypeEnum.Income,
					Description = "Income account for our users",
					OwnerId = _ids[1]
				}
		   );
		}
	}
}
