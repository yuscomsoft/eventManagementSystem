using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
}
