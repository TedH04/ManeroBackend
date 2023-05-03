using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;
using WebApi.Contexts;

namespace WebApi.Repositories.MainRepo
{
	public abstract class Repository<TEntity, TContext>  where TEntity : class where TContext : DbContext
	{
		TContext _context;

		protected Repository(TContext context)
		{
			_context = context;
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			try
			{
				_context.Set<TEntity>().Add(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch { return null!; }
		}

		public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
		{
			try
			{
				var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
				return entity!;
			}
			catch { }

			return null!;
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			try
			{
				return await _context.Set<TEntity>().ToListAsync();
			}
			catch { return new List<TEntity>(); }
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
		{
			try
			{
				return await _context.Set<TEntity>().Where(expression).ToListAsync();
			}
			catch { return new List<TEntity>(); }
		}

		public virtual async Task<TEntity> UpdateAsync(TEntity entity)
		{
			try
			{
				_context.Set<TEntity>().Update(entity);
				await _context.SaveChangesAsync();
				return entity;
			}
			catch { return null!; }
		}

		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			try
			{
				_context.Set<TEntity>().Remove(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch { return false; }
		}
	}
}
