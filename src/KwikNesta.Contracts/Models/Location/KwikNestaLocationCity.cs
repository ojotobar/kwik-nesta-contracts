using EFCore.CrudKit.Library.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace KwikNesta.Contracts.Models.Location
{
    public class KwikNestaLocationCity : EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;

        public Guid CountryId { get; set; }
        public KwikNestaLocationCountry? Country { get; set; }

        public Guid StateId { get; set; }
        public KwikNestaLocationState? State { get; set; }
    }
}
