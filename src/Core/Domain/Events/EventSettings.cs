using EventManagment.Domain.Enums;

namespace EventManagment.Domain.Events;
public class EventSettings : AuditableEntity
{
    public Guid EventId { get; set; }
    public string? QrCode { get; set; }
    public string? ShortLink { get; set; }
    public EventType EventType { get; set; } = default!;
    public bool IsRegistrationActive { get; set; }
    public DateTime RegistrationStartDate { get; set; }
    public DateTime RegistrationEndDate { get; set; }
    public DateTime CheckInStartDate { get; set; }
    public string DataSource { get; set; } = default!;
    public bool IsPrivate { get; set; }
}
