using EventManagment.Domain.Events;

namespace EventManagment.Application.DTOs;
public class ParticipantDto : IDto
{
    public Guid EventId { get; set; }
    public string? MemberNumber { get; set; }
    public ParticipantType ParticipantType { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Tiltle { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Gender { get; set; } 
    public string Address { get; set; }
    public string? AdditionalInformation { get; set; }
    public string EventRegistrationNumber { get; set; } 
    public bool CheckedIn { get; set; }
    public DateTime? CheckInDate { get; set; }
}
