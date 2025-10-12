namespace KwikNesta.Contracts.DTOs
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public bool IsDeprecated { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
    }
}
