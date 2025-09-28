using EFCore.CrudKit.Library.Models;
using KwikNesta.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace KwikNesta.Contracts.Models
{
    public class KwikNestaAuditLog : EntityBase
    {
        [Required]
        public AuditDomain Domain { get; set; }
        [Required]
        public Guid DomainId { get; set; }
        [Required]
        public AuditAction Action { get; set; }
        [Required]
        public string PerformedBy { get; set; } = string.Empty;
        [Required]
        public string PerformedOnProfileId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}