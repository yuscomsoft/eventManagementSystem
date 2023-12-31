﻿using EventManagment.Application.DTOs;
using EventManagment.Application.Participants;
using EventManagment.Domain.Events;
using EventManagment.Infrastructure.Common.Models;

namespace EventManagment.Host.Controllers.Participants;

public class ParticipantsController : VersionNeutralApiController
{

    [HttpGet("{eventId:guid}/event")]
    [MustHavePermission(FSHAction.View, FSHResource.Participants)]
    [OpenApiOperation("Get a list of all participant by available filters.", "")]
    public async Task<PaginationResponse<ParticipantDto>> GetListAsync(Guid eventId, int? jamaatId, int? circuitId, ParticipantType? participantType)
    {
        return await Mediator.Send(new GetParticipantsByEventRequest(eventId, jamaatId, circuitId, participantType));
    }

    [HttpGet("{participantId:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Participants)]
    [OpenApiOperation("Get participant details.", "")]
    public async Task<ParticipantDto> GetAsync(Guid eventId, Guid participantId)
    {
        return await Mediator.Send(new GetParticipantByEventIdRequest(eventId, participantId));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Participants)]
    [OpenApiOperation("Create a new Participants.", "")]
    public Task<Result<Guid>> CreateAsync(CreateParticipantRequest request)
    {
        return Mediator.Send(request);
    }
}
