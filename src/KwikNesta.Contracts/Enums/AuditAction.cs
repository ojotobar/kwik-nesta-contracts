using System.ComponentModel;

namespace KwikNesta.Contracts.Enums
{
    public enum AuditAction
    {
        [Description("Logged In")]
        LoogedIn = 1,
        [Description("Logged Out")]
        LoggedOut,
        [Description("Updated Profile")]
        UpdatedProfile,
        [Description("Deactivated Account")]
        DeactivatedAccount,
        [Description("Reactivated Account")]
        ReactivatedAccount,
        [Description("Suspended Account")]
        SuspendedAccount,
        [Description("Changed Password")]
        ChangedPassword
    }
}
