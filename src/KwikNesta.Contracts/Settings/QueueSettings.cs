namespace KwikNesta.Contracts.Settings
{
    public class QueueSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string ExchangeType { get; set; } = string.Empty;
        public string DeadLetterExchange { get; set; } = string.Empty;
    }
}
