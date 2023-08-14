using EventManagment.Application.Members;
using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants;

public class CreateGuestParticipantRequest : IRequest<Guid>
{
    public Guid EventId { get; set; }
    public string MemberNumber { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string? Title { get; set; }

}

public class CreateGuestParticipantRequestHandler : IRequestHandler<CreateGuestParticipantRequest, Guid>
{
    private readonly IRepository<Participant> _repository;
    private readonly IFileStorageService _file;
    private readonly IMemberService _memberService;

    public CreateGuestParticipantRequestHandler(IRepository<Participant> repository, IFileStorageService file, IMemberService memberService) =>
        (_repository, _file, _memberService) = (repository, file, memberService);

    public async Task<Guid> Handle(CreateGuestParticipantRequest request, CancellationToken cancellationToken)
    {
        // TODO: USE THE MEMBER NUMBER FROM THE REQUEST TO FETCH THE MEMBER INFORMATION FROM THE MEMBER SERVICE
        var member = await _memberService.GetAsync(request.MemberNumber, cancellationToken);
        // TODO: HANDLE WHEN THE MEMBER NUMBER DOES NOT EXIST FROM THE MEMBER SERVICE
        if(member is null)
        {
            throw new ArgumentNullException($"Invalid Member Number{request.MemberNumber}");
        }
        // TODO: IMPLEMENT A PRIVATE METHOD IN AN HELPER CLASS TO GENERATE REGISTRATION NUMBER FOR THE PARTICIPANT BASED ON THE EVENT
        
        // TODO: THE PARTICIPANT OBJECT SHOULD BE CREATED FROM THE DOMAIN CONSTRUCTOR IN THE PARTICIPANT CLASS.
        var participant = new Participant(request.MemberNumber,request.FirstName, request.LastName, request.Address,
            request.PhoneNumber, request.Email, request.Gender, request.Title, ParticipantType.Guest);

        // Add Domain Events to be raised after the commit
        participant.DomainEvents.Add(EntityCreatedEvent.WithEntity(participant));

        await _repository.AddAsync(participant, cancellationToken);

        // TODO: GENERATE TAG/TICKET DOWNLOAD LINK TO BE SENT VIA SMS OR EMAIL
        // TODO: SEND AN SMS, WHATSAPP OR EMAIL MESSAGE TO THE REGISTERED PARTICIPANT, CALL AN INOTIFICATION SERVICE TO DO THIS. OR USE A BACKGROUND JOB , ADDING THE REGISTRATION TO A QUEUE

        return participant.Id;
    }
}