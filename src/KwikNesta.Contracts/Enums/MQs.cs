using System.ComponentModel;

namespace KwikNesta.Contracts.Enums
{
    public enum MQs
    {
        [Description("notification")]
        Notification,
        [Description("audit")]
        Audit,
        [Description("dataload")]
        DataLoad
    }
}
