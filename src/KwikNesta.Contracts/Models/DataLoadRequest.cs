using KwikNesta.Contracts.Enums;

namespace KwikNesta.Contracts.Models
{
    public class DataLoadRequest
    {
        public DataLoadType Type { get; set; }
        public string RequesterEmail { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
