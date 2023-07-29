using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Participants.Specifications;
public class GetParticipantByEventIdSpec : Specification<Participant, ParticipantDto>, ISingleResultSpecification
{
    public GetParticipantByEventIdSpec(Guid eventId, Guid participantId) =>
        Query
            .Where(p => p.Id == participantId && p.EventId == eventId);
}
