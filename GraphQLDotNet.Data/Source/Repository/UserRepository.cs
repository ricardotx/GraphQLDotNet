using GraphQLDotNet.Core.Source.Contracts.Repositories;
using GraphQLDotNet.Core.Source.Models;
using GraphQLDotNet.Data.Source.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source.Repository
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly ApplicationContext _db;

		public UserRepository(ApplicationContext context) : base(context)
		{
			_db = context;
		}

		public async Task<IEnumerable<User>> FindAllWithRoleAsync(Expression<Func<User, bool>> expression)
		{
			return await _db.Users.Include(x => x.Role).Where(expression).ToListAsync();
		}

		public async Task<IEnumerable<User>> FindAllWithRoleAsync()
		{
			return await _db.Users.Include(x => x.Role).ToListAsync();
		}

		public async Task<User> FindByIdWithRoleAsync(Guid id)
		{
			return await _db.Users
				.Include(user => user.Role)
				.Where(user => user.Id == id)
				.FirstOrDefaultAsync();
		}

		public async Task<User> FindOneWithRoleAsync(Expression<Func<User, bool>> expression)
		{
			return await _db.Users.Include(x => x.Role).SingleOrDefaultAsync(expression);
		}
	}
}
