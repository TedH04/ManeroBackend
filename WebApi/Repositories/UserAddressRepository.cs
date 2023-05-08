using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Repositories.MainRepo;

namespace WebApi.Repositories
{
    public class UserAddressRepository : Repository<UserAddressEntity, IdentityContext>
    {
        public UserAddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
