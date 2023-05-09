using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepo;

        public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepo)
        {
            _addressRepo = addressRepo;
            _userAddressRepo = userAddressRepo;
        }

        public async Task<AddressResponse> GetOrCreateAsync(AddressRequest request)
        {
            var addressEntity = await _addressRepo.GetAsync(x =>
                x.Title == request.Title &&
                x.StreetName == request.StreetName &&
                x.City == request.City &&
                x.PostalCode == request.PostalCode
            );

            addressEntity ??= await _addressRepo.AddAsync(request);

            return addressEntity;
        }

        public async Task AddUserAddressAsync(UserAddressEntity userAddressEntity)
        {
            await _userAddressRepo.AddAsync(userAddressEntity);
        }
    }
}
