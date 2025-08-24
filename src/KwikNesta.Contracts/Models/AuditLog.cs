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
        public string PerformedOnProfileId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Initializes and returns a new <see cref="AuditLog"/> instance 
        /// with the provided details of the action performed by a user 
        /// on a given profile within a specified domain.
        /// </summary>
        /// <param name="actionBy">The ID of the user performing the action.</param>
        /// <param name="profileId">The ID of the profile on which the action is performed.</param>
        /// <param name="domainId">The unique identifier of the domain where the action takes place.</param>
        /// <param name="domain">The domain category of the action (e.g., User, System, etc.).</param>
        /// <param name="action">The type of action performed (e.g., Create, Update, Delete).</param>
        /// <returns>A populated <see cref="AuditLog"/> object.</returns>
        public static AuditLog Initialize(string actionBy, string profileId, Guid domainId, AuditDomain domain, AuditAction action)
        {
            return new AuditLog
            {
                PerformedBy = actionBy,
                DomainId = domainId,
                Domain = domain,
                Action = action,
                PerformedOnProfileId = profileId
            };
        }
    }
}
