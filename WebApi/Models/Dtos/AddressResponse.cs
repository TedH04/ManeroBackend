using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class AddressResponse
	{
        public int Id { get; set; }
        public string Title { get; set; } = null!;
		public string StreetName { get; set; } = null!;
		public string PostalCode { get; set; } = null!;
		public string City { get; set; } = null!;

		public static implicit operator AddressEntity(AddressResponse model)
		{
			return new AddressEntity
			{
				Id = model.Id,
				Title = model.Title,
				StreetName = model.StreetName,
				PostalCode = model.PostalCode,
				City = model.City
			};
		}
	}
}
