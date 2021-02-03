using GraphQLDotNet.Core.Source.Repositories;
using GraphQLDotNet.Data.Source.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphQLDotNet.Data.Source.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		protected readonly ApplicationContext _context;

		public BaseRepository(ApplicationContext context)
		{
			_context = context;
		}

		// Set this as a virtual method to allow us to override this implementation when we need it!
		public virtual async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
		}

		public async Task<int> CountAsync()
		{
			return await _context.Set<TEntity>().CountAsync();
		}

		public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _context.Set<TEntity>().Where(expression).ToListAsync();
		}

		public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _context.Set<TEntity>().SingleOrDefaultAsync(expression);
		}

		public async Task<TEntity> FindOneAsync()
		{
			return await _context.Set<TEntity>().SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(Guid id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}
	}
}
