namespace KwikNesta.Contracts.Models.Location
{
    public class KwikNestaState
    {
        public Guid Id { get; set; }
        public bool IsDeprecated { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string ISO2 { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string? Type { get; set; }
    }
}
