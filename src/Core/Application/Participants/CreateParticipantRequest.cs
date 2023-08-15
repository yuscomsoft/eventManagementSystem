using EventManagment.Application.Common.WhatsappMessages;
using EventManagment.Application.DTOs;
using EventManagment.Application.Members;
using EventManagment.Application.Participants.Specifications;
using EventManagment.Application.Utility;
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
    private readonly IRepository<Event> _eventRpository;
    private readonly IWhatsappMessage _whatsappMessageService;
    private readonly IMemberService _memberService;
    private readonly IRepository<Participant> _repository;
    private readonly IFileStorageService _file;

    public CreateParticipantRequestHandler(IRepository<Participant> repository, IFileStorageService file, IRepository<Event> eventRpository, IWhatsappMessage whatsappMessageService, IMemberService memberService) =>
        (_repository, _file, _eventRpository, _whatsappMessageService, _memberService) = (repository, file, eventRpository, whatsappMessageService, memberService);

    public async Task<Result<Guid>> Handle(CreateParticipantRequest request, CancellationToken cancellationToken)
    {
        if (request.MemberNumber is null) return await Result<Guid>.FailAsync("membership number can  not be null, register as guest.");
        //var member = await _memberService.GetByChandaNumberAsync(request.MemberNumber, cancellationToken);
        var member = new MemberDetailsDto
        {
        };
        if (member is null) return await Result<Guid>.FailAsync("invalid membership id.");

        var @event = await _eventRpository.GetByIdAsync(request.EventId);

        var spec = new ParticipantsByEventIdSpec(request.EventId);
        var participants = await _repository.ListAsync(spec, cancellationToken);

        //var registrationNumber = await TicketGeneratorHelper.GenerateEventTicketAsync(@event, participants);
        var registrationNumber = await TicketGeneratorHelper.GenerateEventTicketAsync(@event, new List<ParticipantDto> { new ParticipantDto { EventRegistrationNumber = "JA/2023/00001" } });


        var downloadLink = "dsdjs";

        var participant = new Participant(request.EventId, request.MemberNumber, registrationNumber, ParticipantType.Member, member.FirstName, member.Surname, request.Title, request.Email, request.PhoneNumber, member.JamaatId, member.CircuitId, member.Sex, member.Address, null, registrationNumber, downloadLink, false, null);

        participant.DomainEvents.Add(EntityCreatedEvent.WithEntity(participant));

        await _repository.AddAsync(participant, cancellationToken);

        // TODO: GENERATE TAG/TICKET DOWNLOAD LINK TO BE SENT VIA SMS OR EMAIL
        // TODO: SEND AN SMS, EMAIL MESSAGE TO THE REGISTERED PARTICIPANT, CALL AN INOTIFICATION SERVICE TO DO THIS. OR USE A BACKGROUND JOB , ADDING THE REGISTRATION TO A QUEUE

        // ADD DOWNLOAD LINK TO MESSAGEBODY 
        var messageRequest = new WhatsappMessageRequest
        {
            RecipientNumber = request.PhoneNumber,
            MessageBody = $"You have successfully Register for {@event.EventName}, your registration number is {registrationNumber} here is the link to download your ticket <url>"
        };
        await _whatsappMessageService.SendAsync(messageRequest);

        return await Result<Guid>.SuccessAsync(participant.Id, "Registration Successfully...");
    }
}