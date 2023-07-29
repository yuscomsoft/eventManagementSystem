using EventManagment.Domain.Events;

namespace EventManagment.Application.Events;
public class GetEventRequest : IRequest<EventDetailsDto>
{
    public Guid Id { get; set; }

    public GetEventRequest(Guid id) => Id = id;
}

public class GetEventRequestHandler : IRequestHandler<GetEventRequest, EventDetailsDto>
{
    private readonly IRepository<Event> _repository;
    private readonly IStringLocalizer _t;

    public GetEventRequestHandler(IRepository<Event> repository, IStringLocalizer<GetEventRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<EventDetailsDto> Handle(GetEventRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Event, EventDetailsDto>)new EventByIdWithEventSettingsSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Event {0} Not Found.", request.Id]);
}
