﻿using EFCore.CrudKit.Library.Models;
using System.ComponentModel.DataAnnotations;

namespace KwikNesta.Contracts.Models.Location
{
    public class KwikNestaLocationCountry : EntityBase
    {
        [Required]
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

        public List<KwikNestaLocationTimeZone> TimeZones { get; set; } = [];
        public List<KwikNestaLocationState> States { get; set; } = [];
        public List<KwikNestaLocationCity> Cities { get; set; } = [];
    }
}
