using KwikNesta.Contracts.Enums;

namespace KwikNesta.Contracts.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public AuditDomain Domain { get; set; }
        public Guid DomainId { get; set; }
        public AuditAction Action { get; set; }
        public string PerformedBy { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public static AuditLog Initialize(string actionBy, Guid domainId, AuditDomain domain, AuditAction action)
        {
            return new AuditLog
            {
                PerformedBy = actionBy,
                DomainId = domainId,
                Domain = domain,
                Action = action
            };
        }
    }
}
