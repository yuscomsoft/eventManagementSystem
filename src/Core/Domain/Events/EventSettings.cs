using EventManagment.Domain.Enums;

namespace EventManagment.Domain.Events;
public class EventSettings : AuditableEntity
{
    public Guid EventId { get; private set; }
    public string? EventQrCode { get; private set; }
    public string? ShortLink { get; private set; }
    public EventType EventType { get; private set; } = default!;
    public bool IsRegistrationActive { get; private set; }
    public DateTime? RegistrationStartDate { get; private set; }
    public DateTime? RegistrationEndDate { get; private set; }
    public DateTime? CheckInStartDate { get; private set; }
    public string DataSource { get; private set; } = default!;
    public bool IsPrivate { get; private set; }
    public Event Event { get; private set; }

    public EventSettings(DefaultIdType eventId, string? eventQrCode, string? shortLink, EventType eventType, bool isRegistrationActive, DateTime? registrationStartDate, DateTime? registrationEndDate, DateTime? checkInStartDate, string dataSource, bool isPrivate)
    {
        EventId = eventId;
        EventQrCode = eventQrCode;
        ShortLink = shortLink;
        EventType = eventType;
        IsRegistrationActive = isRegistrationActive;
        RegistrationStartDate = registrationStartDate;
        RegistrationEndDate = registrationEndDate;
        CheckInStartDate = checkInStartDate;
        DataSource = dataSource;
        IsPrivate = isPrivate;
    }
}
