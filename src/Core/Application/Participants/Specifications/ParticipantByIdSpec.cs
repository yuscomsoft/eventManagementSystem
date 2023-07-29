using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Participants.Specifications;
public class ParticipantById : Specification<Participant, ParticipantDto>, ISingleResultSpecification
{
    public ParticipantById(Guid participantId) =>
        Query
            .Where(p => p.Id == participantId);
}
