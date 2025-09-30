﻿namespace KwikNesta.Contracts.Models
{
    public class JwtSetting
    {
        public string IdentityService { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string RoleClaim { get; set; } = string.Empty;
        public string IssuerSigningKey { get; set; } = string.Empty;
    }
}
