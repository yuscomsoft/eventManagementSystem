using EventManagment.Application.Catalog.Products;
using EventManagment.Application.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Host.Controllers;

public class EventController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Events)]
    [OpenApiOperation("Create a new Event.", "")]
    public Task<Guid> CreateAsync(CreateEventRequest request)
    {
        return Mediator.Send(request);
    }
}
