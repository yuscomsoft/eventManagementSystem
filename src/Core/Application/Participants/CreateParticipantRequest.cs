using EventManagment.Application.Catalog.Products;
using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Participants;
public class CreateParticipantRequest : IRequest<DefaultIdType>
{
    public string? MemberNumber { get; set; }
    public Guid EventId { get; set; }
    public ParticipantType ParticipantType { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Tiltle { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Gender { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string? AdditionalInformation { get; set; }
    public string EventRegistrationNumber { get; set; } = default!;
    public bool CheckedIn { get; set; }
    public DateTime? CheckInDate { get; set; }


    public class CreateParticipantRequestHandler : IRequestHandler<CreateParticipantRequest, Guid>
    {
        private readonly IRepositoryWithEvents<Participant> _repository;
        private readonly IFileStorageService _file;

        public CreateParticipantRequestHandler(IRepositoryWithEvents<Participant> repository, IFileStorageService file) =>
            (_repository, _file) = (repository, file);

        public async Task<Guid> Handle(CreateParticipantRequest request, CancellationToken cancellationToken)
        {
            var participant = new Participant(request.EventId, request.MemberNumber, request.ParticipantType, request.FirstName, request.LastName, request.Tiltle,request.Email,request.PhoneNumber,request.Gender, request.Address, request.AdditionalInformation,request.EventRegistrationNumber, request.CheckedIn,request.CheckInDate);

            var response = await _repository.AddAsync(participant, cancellationToken);

            // Add Domain Events to be raised after the commit
            participant.DomainEvents.Add(EntityCreatedEvent.WithEntity(participant));


            return response.Id;
        }

    }
}
