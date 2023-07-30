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
    public EventSettings EventSettings { get; set; }
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
    public EventSettings AddEventSettings(Event even, EventType eventType, DateTime? registrationStartingDate, DateTime? registrationEndDate, DateTime? checkedInStartDate, string dataSource, bool isPrivate)
    {
        if(registrationStartingDate > even.CreatedOn)
        {
            throw new ArgumentException("The starting date for Registration cannot be greter than the date event is created ");
        }
        if(registrationEndDate > even.StartingDate)
        {
            throw new ArgumentException("the registration starting must not be greater than event starting date");
        }
        if(registrationStartingDate > registrationEndDate)
        {
            throw new ArgumentException("the registration starting must not be greater than registration ending date");
        }
        if(registrationEndDate > even.EndingDate)
        {
            throw new ArgumentException("the registration ending date must not be greater than event ending date");
        }
        return new EventSettings
        {
            EventId = even.Id,
            Event = even,
            EventType = eventType,
            RegistrationEndDate = registrationEndDate,
            RegistrationStartDate = checkedInStartDate,
            DataSource = dataSource,
            CheckInStartDate = checkedInStartDate,
            IsPrivate = isPrivate,
            IsRegistrationActive = registrationStartingDate.Equals(DateTime.UtcNow) ? true : false,
        };

    }
}
