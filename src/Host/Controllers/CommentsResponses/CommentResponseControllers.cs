using EventManagment.Application.CommentResponses;
using EventManagment.Application.Comments;
using EventManagment.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Host.Controllers.CommentResponce;
[Route("api/[controller]")]
[ApiController]
public class CommentResponseControllers : VersionedApiController
{
    //[HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.CommentsResponces)]
    //[OpenApiOperation("Add  Responce To A Comment.", "")]
    //public Task<Guid> CreateAsync(CreateCommentResponceRequest request)
    //{
    //    return Mediator.Send(request);
    //}

    //[HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.CommentsResponces)]
    //[OpenApiOperation("Update A Response To A Comment.", "")]
    //public async Task<ActionResult<Guid>> UpdateAsync(UpdateCommentResponseRequest request, Guid id)
    //{
    //    return id != request.CommentId
    //        ? BadRequest()
    //        : Ok(await Mediator.Send(request));
    //}

    //[HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.CommentsResponces)]
    //[OpenApiOperation("Search All Respponse to Comments using available filters.", "")]
    //public Task<PaginationResponse<CommentResponseDto>> SearchAsync(SearchAllCommentResponsesByEventRequest request)
    //{
    //    return Mediator.Send(request);
    //}
}
