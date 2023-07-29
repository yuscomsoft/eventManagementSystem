using EventManagment.Application.Catalog.Products;
using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;
using MediatR;

namespace EventManagment.Application.Participants.Specifications;
public class ParticipantsByEventSpec : EntitiesByPaginationFilterSpec<Participant, ParticipantDto>
{
    public ParticipantsByEventSpec(GetParticipantsByEventRequest filter)
        : base(filter) =>
        Query.
        OrderBy(c => c.FirstName, !filter.HasOrderBy())
        .Where(p => p.EventId.Equals(filter.EventId))
        .Where(p => p.ParticipantType.Equals(filter.ParticipantType!.Value), filter.ParticipantType.HasValue)
        .Where(p => p.JamaatId.Equals(filter.JamaatId!.Value), filter.JamaatId.HasValue)
        .Where(p => p.CircuitId.Equals(filter.CircuitId!.Value), filter.CircuitId.HasValue);
}