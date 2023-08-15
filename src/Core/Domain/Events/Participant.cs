namespace EventManagment.Domain.Events;
public class Participant : AuditableEntity, IAggregateRoot
{

    public Guid EventId { get; set; }
    public string? MemberNumber { get; private set; }
    public string RegistrationNumber { get; private set; } = default!;
    public ParticipantType ParticipantType { get; private set; }
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string? Tiltle { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public int? JamaatId { get; private set; }
    public int? CircuitId { get; private set; }
    public string Gender { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public string? AdditionalInformation { get; private set; }
    public string? TicketQrCode { get; private set; }
    public string TicketDownloadLink { get; private set; } = default!;
    public bool CheckedIn { get; private set; }
    public DateTime? CheckInDate { get; private set; }

    // TODO: ADD DOMAIN CONSTRUCTOR TO CREATE PARTICIPANT
    public Participant(DefaultIdType eventId, string? memberNumber, string registrationNumber, ParticipantType participantType, string firstName, string lastName, string? tiltle, string? email, string? phoneNumber, int? jamaatId, int? circuitId, string gender, string address, string? additionalInformation, string? ticketQrCode, string ticketDownloadLink, bool checkedIn, DateTime? checkInDate)
    {
        EventId = eventId;
        MemberNumber = memberNumber;
        RegistrationNumber = registrationNumber;
        ParticipantType = participantType;
        FirstName = firstName;
        LastName = lastName;
        Tiltle = tiltle;
        Email = email;
        PhoneNumber = phoneNumber;
        JamaatId = jamaatId;
        CircuitId = circuitId;
        Gender = gender;
        Address = address;
        AdditionalInformation = additionalInformation;
        TicketQrCode = ticketQrCode;
        TicketDownloadLink = ticketDownloadLink;
        CheckedIn = checkedIn;
        CheckInDate = checkInDate;
    }

}
