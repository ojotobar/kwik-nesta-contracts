namespace KwikNesta.Infrastruture.Svc.API.Settings
{
    public class ElasticSettings
    {
        public string Url { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string IndexFormat { get; set; } = string.Empty;
        public string IndexPrefix { get; set; } = string.Empty;
    }
}
