using EventManagment.Application.Catalog.Products;
using EventManagment.Domain.Common.Events;
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

        var eventt = new Event(request.EventName, request.StartingDate, request.EndingDate, request.EventYear, request.Location, eventImagePath);

        // Add Domain Events to be raised after the commit
        eventt.DomainEvents.Add(EntityCreatedEvent.WithEntity(eventt));

        await _repository.AddAsync(eventt, cancellationToken);

        return eventt.Id;
    }
}
