using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Domain.Events;
public class Participant : AuditableEntity, IAggregateRoot
{
    public Guid EventId { get; set; }
    public string? MemberNumber { get; set; }
    public ParticipantType ParticipantType { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Tiltle { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? JamaatId { get; set; }
    public int? CircuitId { get; set; }
    public string Gender { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string? AdditionalInformation { get; set; }
    public string EventRegistrationNumber { get; set; } = default!;
    public bool CheckedIn { get; set; }
    public DateTime? CheckInDate { get; set; }

    public Participant(DefaultIdType eventId, string? memberNumber, ParticipantType participantType, string firstName, string lastName, string? tiltle, string? email, string? phoneNumber, string gender, string address, string? additionalInformation, string eventRegistrationNumber, bool checkedIn, DateTime? checkInDate)
    {
        EventId = eventId;
        MemberNumber = memberNumber;
        ParticipantType = participantType;
        FirstName = firstName;
        LastName = lastName;
        Tiltle = tiltle;
        Email = email;
        PhoneNumber = phoneNumber;
        Gender = gender;
        Address = address;
        AdditionalInformation = additionalInformation;
        EventRegistrationNumber = eventRegistrationNumber;
        CheckedIn = checkedIn;
        CheckInDate = checkInDate;
    }

}
