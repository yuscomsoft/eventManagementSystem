using EventManagment.Domain.Events;

namespace EventManagment.Application.Events;

public class EventByNameSpec : Specification<Event>, ISingleResultSpecification
{
    public EventByNameSpec(string eventName) =>
        Query.Where(p => p.EventName == eventName);
}