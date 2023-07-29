using EventManagment.Application.Catalog.Products;
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
    public bool IsActive { get; set; }

}
public class CreateEventRequestHandler : IRequestHandler<CreateEventRequest, Guid>
{
    private readonly IRepository<Event> _repository;
    private readonly IRepository<EventSettings> _eventSettingRepository;
    private readonly IFileStorageService _file;

    public CreateEventRequestHandler(IRepository<Event> repository, IRepository<EventSettings> eventSettingRepository, IFileStorageService file) =>
        (_repository, _file, _eventSettingRepository ) = (repository, file, eventSettingRepository);

    public async Task<Guid> Handle(CreateEventRequest request, CancellationToken cancellationToken)
    {
        string eventImagePath = await _file.UploadAsync<Event>(request.Image, FileType.Image, cancellationToken);

        var eventt = new Event(request.EventName, request.StartingDate, request.EndingDate, request.EventYear, request.Location, eventImagePath);
        var settings = eventt.AddEventSettings(eventt, request.EventType, request.RegistrationStartDate, request.RegistrationEndDate, request.CheckedInStartDate, request.DataSource, request.IsActive);
        // Add Domain Events to be raised after the commit
        eventt.DomainEvents.Add(EntityCreatedEvent.WithEntity(eventt));
        eventt.DomainEvents.Add(EntityCreatedEvent.WithEntity(settings));

        await _repository.AddAsync(eventt, cancellationToken);
        await _eventSettingRepository.AddAsync(settings, cancellationToken);
        return eventt.Id;
    }
}
