using EventManagment.Application.Common.WhatsappMessages;
using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants;

public class CreateParticipantRequest : IRequest<Guid>
{
    public Guid EventId { get; set; }
    public string? MemberNumber { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}

public class CreateParticipantRequestHandler : IRequestHandler<CreateParticipantRequest, Guid>
{
    private readonly IRepository<Participant> _repository;
    private readonly IFileStorageService _file;
    private readonly IWhatsappMessage _whatsappMessageService;

    public CreateParticipantRequestHandler(IRepository<Participant> repository, IFileStorageService file, IWhatsappMessage whatsappMessageService) =>
        (_repository, _file, _whatsappMessageService) = (repository, file, whatsappMessageService);

    public async Task<Guid> Handle(CreateParticipantRequest request, CancellationToken cancellationToken)
    {
        // TODO: USE THE MEMBER NUMBER FROM THE REQUEST TO FETCH THE MEMBER INFORMATION FROM THE MEMBER SERVICE

        // TODO: HANDLE WHEN THE MEMBER NUMBER DOES NOT EXIST FROM THE MEMBER SERVICE

        // TODO: IMPLEMENT A PRIVATE METHOD IN AN HELPER CLASS TO GENERATE REGISTRATION NUMBER FOR THE PARTICIPANT BASED ON THE EVENT

        // TODO: THE PARTICIPANT OBJECT SHOULD BE CREATED FROM THE DOMAIN CONSTRUCTOR IN THE PARTICIPANT CLASS.
        var participant = new Participant();

        // Add Domain Events to be raised after the commit
        participant.DomainEvents.Add(EntityCreatedEvent.WithEntity(participant));

        await _repository.AddAsync(participant, cancellationToken);

        // TODO: GENERATE TAG/TICKET DOWNLOAD LINK TO BE SENT VIA SMS OR EMAIL
        // TODO: SEND AN SMS, WHATSAPP OR EMAIL MESSAGE TO THE REGISTERED PARTICIPANT, CALL AN INOTIFICATION SERVICE TO DO THIS. OR USE A BACKGROUND JOB , ADDING THE REGISTRATION TO A QUEUE
        var messageRequest = new WhatsappMessageRequest
        {
            RecipientNumber = "+2347031905878",
            MessageBody = "You have successfully Register for Jalsa sala, here is the link to download your ticket <url>"
        };
        await _whatsappMessageService.SendAsync(messageRequest);

        return participant.Id;
    }
}