using System.ComponentModel;

namespace KwikNesta.Contracts.Enums
{
    public enum MQRoutingKey
    {
        [Description("account.email")]
        AccountEmail,
        [Description("audit.trails")]
        AuditTrails
    }
}
