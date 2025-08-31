namespace KwikNesta.Contracts.Models.Location
{
    public class KwikNestaCountry
    {
        public Guid Id { get; set; }
        public bool IsDeprecated { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ISO2 { get; set; } = string.Empty;
        public string ISO3 { get; set; } = string.Empty;
        public string NumericCode { get; set; } = string.Empty;
        public string PhoneCode { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string CurrencyName { get; set; } = string.Empty;
        public string CurrencySymbol { get; set; } = string.Empty;
        public string TLD { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string SubRegion { get; set; } = string.Empty;
        public string Native { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Emoji { get; set; } = string.Empty;
        public string EmojiUnicode { get; set; } = string.Empty;
        public List<KwikNestaTimeZone> TimeZones { get; set; } = [];
    }
}