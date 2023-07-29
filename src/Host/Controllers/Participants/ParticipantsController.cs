using EventManagment.Application.DTOs;
using EventManagment.Application.Participants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Host.Controllers.Participants;

public class ParticipantsController : VersionNeutralApiController
{

    [HttpGet("{eventId:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Participants)]
    [OpenApiOperation("Get a list of all participant by event.", "")]
    public async Task<PaginationResponse<ParticipantDto>> GetListAsync(Guid eventId)
    {
        return await Mediator.Send(new GetParticipantsByEventRequest(eventId));
    }
}
