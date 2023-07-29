using EventManagment.Application.Catalog.Products;
using EventManagment.Application.DTOs;
using EventManagment.Application.Participants.Specifications;
using EventManagment.Domain.Events;
using System.Diagnostics.Metrics;

namespace EventManagment.Application.Participants;
public class GetParticipantsByEventRequest : PaginationFilter, IRequest<PaginationResponse<ParticipantDto>>
{
    public Guid EventId { get; set; } = default!;

    public GetParticipantsByEventRequest(Guid eventId) => EventId = eventId;
}

public class GetParticipantsByEventRequestHandler : IRequestHandler<GetParticipantsByEventRequest, PaginationResponse<ParticipantDto>>
{
    private readonly IReadRepository<Participant> _repository;

    public GetParticipantsByEventRequestHandler(IReadRepository<Participant> repository) => _repository = repository;

    public async Task<PaginationResponse<ParticipantDto>> Handle(GetParticipantsByEventRequest request, CancellationToken cancellationToken)
    {

        var spec = new ParticipantsByEventSpec(request);
        var response = await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
        return response;
    }
}

public class ParticipantMock
{
    private List<Participant> GetFakeParticipants()
    {
        return new List<Participant>
        {
                new Participant()
                {
                    Tiltle = "Mr",
                    Email = "modelEmail",
                    FirstName = "modelFirstName",
                    LastName = "modelLastName",
                    PhoneNumber = "modelPhone",
                    ParticipantType = ParticipantType.Member,
                    EventId = Guid.Parse("0d9339c6-486d-4084-a4f8-2c0987ee49ac"),
                    CreatedBy = Guid.Parse("0d9339c6-486d-4084-a4f8-2c0987ee49ac"),
                    DeletedBy = null,
                    AdditionalInformation = "modelAdditionalInformation",
                    Address = "modelAddress",
                    CheckedIn = false,
                    MemberNumber = "7917",
                    CheckInDate = default(DateTime),
                    Gender = "Male",
                    EventRegistrationNumber = "0d9339c6-486d-4084-a4f8-2c0987ee49ac",
                    DeletedOn = default(DateTime),
                    LastModifiedBy = Guid.Parse("0d9339c6-486d-4084-a4f8-2c0987ee49ac"),
                    LastModifiedOn = default(DateTime),
                },
                new Participant()
                {
                    Tiltle = "Mr",
                    Email = "modelEmail",
                    FirstName = "modelFirstName",
                    LastName = "modelLastName",
                    PhoneNumber = "modelPhone",
                    ParticipantType = ParticipantType.Guest,
                    CreatedBy = Guid.Parse("0d9339c6-486d-4084-a4f8-2c0987ee49ac"),
                    EventId = Guid.Parse("0d9339c6-486d-4084-a4f8-2c0987ee49ac"),
                    DeletedBy = null,
                    AdditionalInformation = "modelAdditionalInformation",
                    Address = "modelAddress",
                    CheckedIn = false,
                    MemberNumber = "5643",
                    CheckInDate = default(DateTime),
                    Gender = "Female",
                    EventRegistrationNumber = "0d9339c6-486d-4084-a4f8-2c0987ee49ac",
                    DeletedOn = default(DateTime),
                    LastModifiedBy = Guid.Parse("0d9339c6-486d-4084-a4f8-2c0987ee49ac"),
                    LastModifiedOn = default(DateTime),
                }
        };
    }
}
