namespace KwikNesta.Contracts.DTOs
{
    public class TimeZoneDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string ZoneName { get; set; } = string.Empty;
        public long GMTOffset { get; set; }
        public string GMTOffsetName { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string TZName { get; set; } = string.Empty;
    }
}
