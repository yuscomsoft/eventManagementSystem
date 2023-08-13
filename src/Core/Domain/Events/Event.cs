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
        EventName = eventName;
        StartingDate = startingDate;
        EndingDate = endingDate;
        EventYear = eventYear;
        ImagePath = imagePath;
        Location = location;
        Status = EventStatus.Upcoming;
    }

    public EventSettings AddEventSettings(DefaultIdType eventId, string? eventQrCode, string? shortLink, EventType eventType, bool isRegistrationActive, DateTime? registrationStartDate, DateTime? registrationEndDate, DateTime? checkInStartDate, string dataSource, bool isPrivate)
    {
        //if (registrationStartDate > @event.CreatedOn)
        //{
        //    throw new ArgumentException("The starting date for Registration cannot be greter than the date event is created ");
        //}

        //if (registrationEndDate > @event.StartingDate)
        //{
        //    throw new ArgumentException("the registration starting must not be greater than event starting date");
        //}

        if (registrationStartDate > registrationEndDate)
        {
            throw new ArgumentException("the registration starting must not be greater than registration ending date");
        }

        //if (registrationEndDate > @event.EndingDate)
        //{
        //    throw new ArgumentException("the registration ending date must not be greater than event ending date");
        //}

        return new EventSettings(eventId, eventQrCode, shortLink, eventType, isRegistrationActive, registrationStartDate, registrationEndDate, checkInStartDate, dataSource, isPrivate);
    }
}