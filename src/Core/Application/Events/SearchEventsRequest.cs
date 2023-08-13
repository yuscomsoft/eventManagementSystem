using EventManagment.Domain.Events;


namespace EventManagment.Application.Events;
public class SearchEventsRequest : PaginationFilter, IRequest<PaginationResponse<EventDto>>
{
    public Guid? EventId { get; set; }
    public string? EventName { get; set; }
    public DateTime? EventDate { get; set; }
}

public class SearchEventsRequestHandler : IRequestHandler<SearchEventsRequest, PaginationResponse<EventDto>>
{
    private readonly IReadRepository<Event> _repository;

    public SearchEventsRequestHandler(IReadRepository<Event> repository) => _repository = repository;

    public async Task<PaginationResponse<EventDto>> Handle(SearchEventsRequest request, CancellationToken cancellationToken)
    {
        var spec = new EventsBySearchRequestWithSettingsSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}
