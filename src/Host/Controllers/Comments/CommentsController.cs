using EventManagment.Application.Catalog.Products;
using EventManagment.Application.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Host.Controllers.Comments;
[Route("api/[controller]")]
[ApiController]
public class CommentsController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Products)]
    [OpenApiOperation("Add New Comment.", "")]
    public Task<Guid> CreateAsync(CreateCommentRequest request)
    {
        return Mediator.Send(request);
    }

}
