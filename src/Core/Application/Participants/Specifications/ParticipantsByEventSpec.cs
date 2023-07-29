using EventManagment.Application.Catalog.Products;
using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants.Specifications;
public class ParticipantsByEventSpec : EntitiesByPaginationFilterSpec<Participant, ParticipantDto>
{
    public ParticipantsByEventSpec(GetParticipantsByEventRequest filter) : base(filter) =>
        Query.
        OrderBy(c => c.FirstName, !filter.HasOrderBy())
        .Where(p => p.EventId.Equals(filter.EventId));
}