using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
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
    public string? Title { get; private set; }
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

    public Participant(string memberNum, string firstName, string lastName, string address, string phoneNum, string email, string gender, string title, ParticipantType participant)
    {
        MemberNumber = memberNum;
        RegistrationNumber = GenerateRandomNumber();
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNum;
        Email = email;
        Gender = gender;
        Title = title;
        ParticipantType = participant;
    }

    public Participant()
    {

    }
    private static string GenerateRandomNumber()
    {
        var registrationNum = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 7);
        return registrationNum;
    }
}
