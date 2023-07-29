using EventManagment.Domain.Enums;

namespace EventManagment.Domain.Events;
public class Event : AuditableEntity, IAggregateRoot
{
    public string EventName { get; set; } = default!;
    public string? ImagePath { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public int EventYear { get; set; }
    public string Location { get; set; } = default!;
    public EventStatus Status { get; set; }
    public ICollection<Participant> Participants { get; set; } = new HashSet<Participant>();
    public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    public Event(string eventName, DateTime startingDate, DateTime endingDate, int eventYear, string location, string? imagePath)
    {
        this.EventName = eventName;
        this.StartingDate = startingDate;
        this.EndingDate = endingDate;
        this.EventYear = eventYear;
        this.ImagePath = imagePath;
        this.Location = location;
        this.Status = EventStatus.Upcoming;

    }
}
