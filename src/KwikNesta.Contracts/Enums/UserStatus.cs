using System.ComponentModel;

namespace KwikNesta.Contracts.Enums
{
    public enum UserStatus
    {
        [Description("Pending Verification")]
        PendingVerification,
        [Description("Active")]
        Active,
        [Description("Deactivated")]
        Deactivated,
        [Description("Suspended")]
        Suspended
    }
}