using CSharpTypes.Extensions.Enumeration;
using KwikNesta.Contracts.Enums;

namespace KwikNesta.Contracts.Models
{
    public class PropertyNotificationEvent
    {
        public string UserId { get; set; } = string.Empty;
        public PropertyNotificationType Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? MetadataJson { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? TriggeredBy { get; set; } 

        public PropertyNotificationEvent Init(string userId,
                                              string propertyTitle,
                                              PropertyNotificationType type,
                                              string? propertyStatus = null,
                                              string? metaData = null,
                                              string? triggeredBy = null)
        {
            var payload = Create(type, propertyTitle, propertyStatus);
            return new PropertyNotificationEvent
            {
                UserId = userId,
                Type = type,
                Title = payload.Title,
                Message = payload.Message,
                MetadataJson = metaData,
                TriggeredBy = triggeredBy
            };
        }

        private static (string Title, string Message) Create(PropertyNotificationType type, 
                                                            string propertyTitle,
                                                            string? propertyStatus)
        {
            switch (type)
            {
                case PropertyNotificationType.AutoVerified:
                    return (
                        type.GetDescription(),
                        $"Great news! Your property \"{propertyTitle}\" has successfully passed our verification checks and is now live on the marketplace.\n\nYou can view your listing and start receiving inquiries right away."
                    );

                case PropertyNotificationType.VerificationFailed:
                    return (
                        type.GetDescription(),
                        $"We reviewed your property \"{propertyTitle}\", but we couldn’t verify its location.\n\nTo complete verification, please confirm your property’s exact location on the map and submit a verification request.\n\nOnce verified, your listing will go live automatically."
                    );

                case PropertyNotificationType.DocumentApproved:
                    return (
                        type.GetDescription(),
                        $"Congratulations! Your ownership documents for \"{propertyTitle}\" have been reviewed and approved.\n\nYour property now carries a Verified Badge, helping buyers and renters recognize it as an authentic, trusted listing."
                    );

                case PropertyNotificationType.DocumentRejected:
                    return (
                        type.GetDescription(),
                        $"We reviewed the ownership documents you submitted for \"{propertyTitle}\", but we couldn’t confirm ownership details.\n\nPlease review your submission and try again with clearer or complete documentation.\n\nOur support team is available if you need assistance."
                    );
                case PropertyNotificationType.Created:
                    return (
                        type.GetDescription(),
                        $"You’ve successfully created a new property draft titled \"{propertyTitle}\".\n\nComplete your listing details and upload photos to get it ready for verification."
                    );

                case PropertyNotificationType.Updated:
                    return (
                        type.GetDescription(),
                        $"The information for \"{propertyTitle}\" has been updated successfully.\n\nAny changes that affect verification will be reviewed automatically in the background."
                    );

                case PropertyNotificationType.DocumentUploaded:
                    return (
                        type.GetDescription(),
                        $"Your ownership document for \"{propertyTitle}\" has been received.\n\nOur team will review it shortly and notify you once verification is complete."
                    );

                case PropertyNotificationType.ManualVerificationRequested:
                    return (
                        type.GetDescription(),
                        $"We’ve received your manual verification request for \"{propertyTitle}\".\n\nOur system will recheck your listing details and location shortly. You’ll be notified once the review is complete."
                    );

                case PropertyNotificationType.StatusChanged:
                    return (
                        type.GetDescription(),
                        $"The status of \"{propertyTitle}\" has been updated to {propertyStatus ?? "Unknown"}.\n\nYou can view the current status in your dashboard for more details."
                    );
                default:
                    return (
                        "Property Notification",
                        $"There's an update on your property \"{propertyTitle}\"."
                    );
            }
        }
    }
}