using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants.EventHandlers;

public class ParticipantCreatedEventHandler : EventNotificationHandler<EntityCreatedEvent<Participant>>
{
    private readonly ILogger<ParticipantCreatedEventHandler> _logger;

    public ParticipantCreatedEventHandler(ILogger<ParticipantCreatedEventHandler> logger) => _logger = logger;

    public override Task Handle(EntityCreatedEvent<Participant> @event, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{event} Triggered", @event.GetType().Name);
        return Task.CompletedTask;
    }
}