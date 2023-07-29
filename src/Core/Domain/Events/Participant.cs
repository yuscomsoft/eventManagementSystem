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
    public string Gender { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string? AdditionalInformation { get; set; }
    public string EventRegistrationNumber { get; set; } = default!;
    public bool CheckedIn { get; set; }
    public DateTime? CheckInDate { get; set; }
}
