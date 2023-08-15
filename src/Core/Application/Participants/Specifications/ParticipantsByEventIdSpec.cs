using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants.Specifications;
public class ParticipantsByEventIdSpec : Specification<Participant, ParticipantDto>
{
    public ParticipantsByEventIdSpec(Guid eventId)
       =>
        Query
        .Where(p => p.EventId.Equals(eventId))
        .OrderBy(c => c.RegistrationNumber);
}