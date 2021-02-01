using GraphQLDotNet.Core.Source.Contracts.Repositories;
using GraphQLDotNet.Core.Source.Models;
using GraphQLDotNet.Data.Source.Context;

using System;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source.Repositories
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		private readonly ApplicationContext _db;

		public RoleRepository(ApplicationContext context) : base(context)
		{
			_db = context;
		}

		public override async Task AddAsync(Role role)
		{
			role.Id = Guid.NewGuid();
			await _db.Roles.AddAsync(role);
		}
	}
}
