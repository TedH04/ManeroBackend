using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
    public class AddressRequest
    {
        public string Title { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        //public string UserId { get; set; } = null!;

        public static implicit operator AddressEntity(AddressRequest request)
        {
            return new AddressEntity()
            {
                Title = request.Title,
                StreetName = request.StreetName,
                PostalCode = request.PostalCode,
                City = request.City,
            };
        }
    }
}
