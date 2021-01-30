using GraphQLDotNet.Data.Context.Configurations;
using GraphQLDotNet.Data.Models;

using Microsoft.EntityFrameworkCore;

using System;

namespace GraphQLDotNet.Data.Context
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Account> Accounts { get; set; }
		public DbSet<Owner> Owners { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };
			modelBuilder.ApplyConfiguration(new OwnerConfiguration(ids));
			modelBuilder.ApplyConfiguration(new AccountConfiguration(ids));
		}
	}
}
