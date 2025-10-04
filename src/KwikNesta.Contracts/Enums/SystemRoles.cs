using System.ComponentModel;

namespace KwikNesta.Contracts.Enums
{
    public enum SystemRoles
    {
        None = 0,
        [Description("SuperAdmin")]
        SuperAdmin,
        [Description("Admin")]
        Admin,
        [Description("LandLord")]
        LandLord,
        [Description("Tenant")]
        Tenant,
        [Description("Agent")]
        Agent
    }
}
