namespace PubQuizOrganizerFrontend.Models.Dto.LocationDto
{
    public class LocationDetailedDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? PostalCodeId { get; set; }
        public string PostalCode { get; set; } = null!;
        public int? CityId { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
