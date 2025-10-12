using KwikNesta.Contracts.Enums;

namespace KwikNesta.Contracts.Commands
{
    public class AuditCommand
    {
        public AuditDomain Domain { get; set; }
        public Guid DomainId { get; set; }
        public AuditAction Action { get; set; }
        public string PerformedBy { get; set; } = string.Empty;
        public string TargetId { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}