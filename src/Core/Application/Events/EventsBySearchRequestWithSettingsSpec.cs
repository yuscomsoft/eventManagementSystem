using EventManagment.Domain.Events;

namespace EventManagment.Application.Events;
public class EventsBySearchRequestWithSettingsSpec : EntitiesByPaginationFilterSpec<Event, EventDto>
{
    public EventsBySearchRequestWithSettingsSpec(SearchEventsRequest request)
       : base(request) =>
       Query
           .Include(p => p.EventSettings)
           .OrderBy(c => c.StartingDate, !request.HasOrderBy());
}
