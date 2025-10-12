namespace KwikNesta.Contracts.DTOs
{
    public class AuditDto
    {
        public string Domain { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string PerformedBy { get; set; } = string.Empty;
        public string TargetId { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}