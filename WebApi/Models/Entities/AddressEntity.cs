using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
	public class AddressEntity
	{
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string StreetName { get; set; } = null!;
		public string PostalCode { get; set; } = null!;
		public string City { get; set; } = null!;

        public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();


        public static implicit operator AddressResponse(AddressEntity entity)
        {
            return new AddressResponse()
            {
                Id = entity.Id,
                Title = entity.Title,
                StreetName = entity.StreetName,
                PostalCode = entity.PostalCode,
                City = entity.City,
            };
        }
    }
}
