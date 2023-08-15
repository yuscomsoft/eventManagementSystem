using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Enums;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Events;
public class CreateEventRequest : IRequest<Guid>
{
    public string EventName { get; set; } = default!;
    public FileUploadRequest? Image { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public int EventYear { get; set; } = default!;
    public string Location { get; set; } = default!;
    public EventType EventType { get; set; } = default!;
    public DateTime? RegistrationStartDate { get; set; }
    public DateTime? RegistrationEndDate { get; set; }
    public DateTime? CheckedInStartDate { get; set; }
    public string DataSource { get; set; }
    public DateTime? CheckInStartDate { get; set; }
    public bool IsPrivate { get; set; }
}
public class CreateEventRequestHandler : IRequestHandler<CreateEventRequest, Guid>
{
    private readonly IRepository<Event> _repository;
    private readonly IFileStorageService _file;

    public CreateEventRequestHandler(IRepository<Event> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);

    public async Task<Guid> Handle(CreateEventRequest request, CancellationToken cancellationToken)
    {
        string eventImagePath = await _file.UploadAsync<Event>(request.Image, FileType.Image, cancellationToken);

        var @event = new Event(request.EventName, request.StartingDate, request.EndingDate, request.EventYear, request.Location, eventImagePath);

        string eventQrCode = @event.Id.ToString();
        string shortLink = @event.Id.ToString();

        var settings = @event.AddEventSettings(@event.Id, eventQrCode, shortLink, request.EventType, isRegistrationActive: true, request.RegistrationStartDate, request.RegistrationEndDate, request.CheckInStartDate, request.DataSource, request.IsPrivate);

        @event.EventSettings = settings;

        // Add Domain Events to be raised after the commit
        @event.DomainEvents.Add(EntityCreatedEvent.WithEntity(@event));
        @event.DomainEvents.Add(EntityCreatedEvent.WithEntity(settings));

        await _repository.AddAsync(@event, cancellationToken);
        return @event.Id;
    }
}
