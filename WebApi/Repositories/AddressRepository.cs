using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Repositories.MainRepo;

namespace WebApi.Repositories
{
    public class AddressRepository : Repository<AddressEntity, IdentityContext>
    {
        public AddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
