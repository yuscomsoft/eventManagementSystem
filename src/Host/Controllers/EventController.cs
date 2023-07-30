using EventManagment.Application.Events;

namespace EventManagment.Host.Controllers;

public class EventController : VersionedApiController
{

    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Events)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<EventDto>> SearchAsync(SearchEventsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Events)]
    [OpenApiOperation("Create a new Event.", "")]
    public Task<Guid> CreateAsync(CreateEventRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Events)]
    [OpenApiOperation("Get event details.", "")]
    public Task<EventDetailsDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetEventRequest(id));
    }
}
