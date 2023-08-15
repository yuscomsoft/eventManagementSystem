using EventManagment.Application.Members;
using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;
using EventManagment.Infrastructure.Common.Models;

namespace EventManagment.Application.Participants;

public class CreateParticipantRequest : IRequest<Result<Guid>>
{
    public Guid EventId { get; set; }
    public string? MemberNumber { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Title { get; set; }
}

public class CreateParticipantRequestHandler : IRequestHandler<CreateParticipantRequest, Result<Guid>>
{
    private readonly IRepository<Participant> _participantRepository;
    private readonly IFileStorageService _file;
    private readonly IMemberService _memberService;

    public CreateParticipantRequestHandler(IRepository<Participant> repository, IFileStorageService file, IMemberService memberService)
    {
        (_participantRepository, _file) = (repository, file);
        _memberService = memberService;
    }

    public async Task<Result<Guid>> Handle(CreateParticipantRequest request, CancellationToken cancellationToken)
    {
        // TODO: USE THE MEMBER NUMBER FROM THE REQUEST TO FETCH THE MEMBER INFORMATION FROM THE MEMBER SERVICE
        if (request.MemberNumber is null) return await Result<Guid>.FailAsync("membership number can  not be null, register as guest.");
        var member = await _memberService.GetByChandaNumberAsync(request.MemberNumber, cancellationToken);
        if (member is null) return await Result<Guid>.FailAsync("invalid membership id.");
        // TODO: HANDLE WHEN THE MEMBER NUMBER DOES NOT EXIST FROM THE MEMBER SERVICE

        // TODO: IMPLEMENT A PRIVATE METHOD IN AN HELPER CLASS TO GENERATE REGISTRATION NUMBER FOR THE PARTICIPANT BASED ON THE EVENT
        var registrationNumber = "dsdjs";
        var shortLink = "dsdjs";
        // TODO: THE PARTICIPANT OBJECT SHOULD BE CREATED FROM THE DOMAIN CONSTRUCTOR IN THE PARTICIPANT CLASS.
        var participant = new Participant(request.EventId, request.MemberNumber, registrationNumber, ParticipantType.Member, member.FirstName, member.Surname, request.Title, request.Email, request.PhoneNumber, member.JamaatId, member.CircuitId, member.Sex, member.Address, null, registrationNumber, shortLink, false, null);

        // Add Domain Events to be raised after the commit
        participant.DomainEvents.Add(EntityCreatedEvent.WithEntity(participant));

        await _participantRepository.AddAsync(participant, cancellationToken);

        // TODO: GENERATE TAG/TICKET DOWNLOAD LINK TO BE SENT VIA SMS OR EMAIL
        // TODO: SEND AN SMS, WHATSAPP OR EMAIL MESSAGE TO THE REGISTERED PARTICIPANT, CALL AN INOTIFICATION SERVICE TO DO THIS. OR USE A BACKGROUND JOB , ADDING THE REGISTRATION TO A QUEUE

        return await Result<Guid>.SuccessAsync(participant.Id, "Registration Successfully...");
    }
}