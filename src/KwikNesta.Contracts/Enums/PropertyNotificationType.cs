using System.ComponentModel;

namespace KwikNesta.Contracts.Enums
{
    public enum PropertyNotificationType
    {
        [Description("Property Draft Created")]
        Created,
        [Description("Property Details Updated")]
        Updated,
        [Description("Property Listed")]
        AutoVerified,
        [Description("Verification Failed")]
        VerificationFailed,
        [Description("Ownership Document Uploaded")]
        DocumentUploaded,
        [Description("Ownership Document Approved - Verified")]
        DocumentApproved,
        [Description("Document Rejected")]
        DocumentRejected,
        [Description("Manual Verification Request Received")]
        ManualVerificationRequested,
        [Description("Property Status Updated")]
        StatusChanged
    }
}
