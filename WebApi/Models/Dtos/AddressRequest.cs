namespace WebApi.Models.Dtos
{
	public class AddressRequest
	{
        public string Title { get; set; } = null!;
        public string StreetName { get; set; } = null!;
		public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string UserId { get; set; } = null!;
	}
}
