using CSharpTypes.Extensions.Enumeration;
using KwikNesta.Contracts.Enums;

namespace KwikNesta.Contracts.Models
{
    public class NotificationMessage
    {
        public string ReceipientName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public EmailType Type { get; set; }
        public string? Reason { get; set; }
        public OtpData? Otp { get; set; }

        public static NotificationMessage Initialize(string email, string name, EmailType type, string? reason = null)
        {
            return new NotificationMessage
            {
                EmailAddress = email,
                ReceipientName = name,
                Type = type,
                Subject = type.GetDescription(),
                Reason = reason
            };
        }

        public static NotificationMessage Initialize(string email, string name, string otp, EmailType type, int expirationInMinutes = 10)
        {
            var expires = DateTime.UtcNow.AddMinutes(expirationInMinutes);

            return new NotificationMessage
            {
                EmailAddress = email,
                ReceipientName = name,
                Type = type,
                Subject = type.GetDescription(),
                Otp = new OtpData
                {
                    Value = otp,
                    Span = (int)Math.Ceiling(expires.Subtract(DateTime.UtcNow).TotalMinutes)
                }
            };
        }
    }
}
