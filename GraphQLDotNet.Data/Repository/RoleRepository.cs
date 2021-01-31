using GraphQLDotNet.Data.Context;
using GraphQLDotNet.Data.Models;
using GraphQLDotNet.Data.Repository.Contracts;

namespace GraphQLDotNet.Data.Repository
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
