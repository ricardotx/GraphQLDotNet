using GraphQLDotNet.Core.Source.DataModels;
using GraphQLDotNet.Data.Source.Configurations;

using Microsoft.EntityFrameworkCore;

using System;

namespace GraphQLDotNet.Data.Source.Context
{
	public class StorageContext : DbContext
	{
		public StorageContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Account> Accounts { get; set; }
		public DbSet<Owner> Owners { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
			var adminRoleId = Guid.NewGuid();

			modelBuilder.ApplyConfiguration(new OwnerConfiguration(ids));
			modelBuilder.ApplyConfiguration(new AccountConfiguration(ids));
			modelBuilder.ApplyConfiguration(new RoleConfiguration(adminRoleId));
			modelBuilder.ApplyConfiguration(new UserConfiguration(adminRoleId));
		}
	}
}
