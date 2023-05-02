using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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

	}
}
