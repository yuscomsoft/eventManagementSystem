using EventManagment.Application.DTOs;
using EventManagment.Application.Participants.Specifications;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants;
public class GetParticipantByEventIdRequest : PaginationFilter, IRequest<ParticipantDto>
{
    public Guid EventId { get; set; } = default!;
    public Guid ParticipantId { get; set; } = default!;

    public GetParticipantByEventIdRequest(DefaultIdType eventId, DefaultIdType participantId) =>
        (EventId, ParticipantId) = (eventId, participantId);
}

public class GetParticipantByEventIdRequestHanderler : IRequestHandler<GetParticipantByEventIdRequest, ParticipantDto>
{
    private readonly IReadRepository<Participant> _repository;

    public GetParticipantByEventIdRequestHanderler(IReadRepository<Participant> repository) => _repository = repository;

    public async Task<ParticipantDto> Handle(GetParticipantByEventIdRequest request, CancellationToken cancellationToken)
    {

        var spec = new GetParticipantByEventIdSpec(request.ParticipantId, request.EventId);
        var response = await _repository.GetBySpecAsync(spec, cancellationToken: cancellationToken);
        return response;
    }
}
