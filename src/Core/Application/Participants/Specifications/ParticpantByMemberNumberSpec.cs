using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants.Specifications;

public class ParticipantByMemberNumberSpec : Specification<Participant>, ISingleResultSpecification
{
    public ParticipantByMemberNumberSpec(string name) =>
        Query.Where(p => p.MemberNumber == name);
}