using EventManagment.Application.Catalog.Products;
using EventManagment.Application.Comments;
using EventManagment.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Host.Controllers.Comments;
[Route("api/[controller]")]
[ApiController]
public class CommentsController : VersionedApiController
{
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Comments)]
    [OpenApiOperation("Add New Comment.", "")]
    public Task<Guid> CreateAsync(CreateCommentRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Comments)]
    [OpenApiOperation("Update a Comment.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCommentRequest request, Guid id)
    {
        return id != request.EventId
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    //[HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Comments)]
    //[OpenApiOperation("Search Comments using available filters.", "")]
    //public Task<PaginationResponse<CommentDto>> SearchAsync(SearchAllCommentsByEventRequest request)
    //{
    //    return Mediator.Send(request);
    //}

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Comments)]
    [OpenApiOperation("Delete a comment.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCommentRequest(id));
    }
}
