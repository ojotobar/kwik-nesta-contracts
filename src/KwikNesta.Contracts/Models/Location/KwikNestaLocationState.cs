using EFCore.CrudKit.Library.Models;
using System.ComponentModel.DataAnnotations;

namespace KwikNesta.Contracts.Models.Location
{
    public class KwikNestaLocationState : EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string ISO2 { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string? Type { get; set; }

        public Guid CountryId { get; set; }
        public KwikNestaLocationCountry? Country { get; set; }
        public List<KwikNestaLocationCity> Cities { get; set; } = [];
    }
}
