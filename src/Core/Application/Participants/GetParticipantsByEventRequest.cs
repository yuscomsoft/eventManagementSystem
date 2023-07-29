using EventManagment.Application.Catalog.Products;
using EventManagment.Application.DTOs;
using EventManagment.Application.Participants.Specifications;
using EventManagment.Domain.Events;
using System.Diagnostics.Metrics;

namespace EventManagment.Application.Participants;
public class GetParticipantsByEventRequest : PaginationFilter, IRequest<PaginationResponse<ParticipantDto>>
{
    public Guid EventId { get; set; } = default!;
    public int? JamaatId { get; set; }
    public int? CircuitId { get; set; }
    public ParticipantType? ParticipantType { get; set; }

    public GetParticipantsByEventRequest(DefaultIdType eventId, int? jamaatId, int? circuitId, ParticipantType? participantType) =>
        (EventId, JamaatId, CircuitId, ParticipantType) = (eventId, jamaatId, circuitId, participantType);
}

public class GetParticipantsByEventRequestHandler : IRequestHandler<GetParticipantsByEventRequest, PaginationResponse<ParticipantDto>>
{
    private readonly IReadRepository<Participant> _repository;

    public GetParticipantsByEventRequestHandler(IReadRepository<Participant> repository) => _repository = repository;

    public async Task<PaginationResponse<ParticipantDto>> Handle(GetParticipantsByEventRequest request, CancellationToken cancellationToken)
    {

        var spec = new ParticipantsByEventSpec(request);
        var response = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
        return response;
    }
}