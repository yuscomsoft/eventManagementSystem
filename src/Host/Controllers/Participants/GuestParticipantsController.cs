using EventManagment.Application.Catalog.Products;
using EventManagment.Application.DTOs;
using EventManagment.Application.Multitenancy;
using EventManagment.Application.Participants;
using EventManagment.Domain.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Host.Controllers.Participants;

public class GuestParticipantsController : VersionNeutralApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Participants)]
    [OpenApiOperation("Register Guest Participant.", "")]
    public Task<Guid> CreateAsyn(CreateGuestParticipantRequest request)
    {
        return Mediator.Send(request);
    }
}
