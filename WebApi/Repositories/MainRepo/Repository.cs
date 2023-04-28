using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApi.Contexts;

namespace WebApi.Repositories.MainRepo
{
	public abstract class Repository<TEntity, TContext>  where TEntity : class 
	{
		private readonly IdentityContext _context;

		protected Repository(IdentityContext context)
		{
			_context = context;
		}

	}
}
