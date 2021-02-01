using GraphQLDotNet.Core.Source.Contracts.Repositories;
using GraphQLDotNet.Core.Source.Models;
using GraphQLDotNet.Data.Source.Context;

namespace GraphQLDotNet.Data.Source.Repository
{
	public class RoleRepository : Repository<Role>, IRoleRepository
	{
		private readonly ApplicationContext _db;

		public RoleRepository(ApplicationContext context) : base(context)
		{
			_db = context;
		}
	}
}
