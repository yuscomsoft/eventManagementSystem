using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Comments;

public class SearchAllCommentsByEventRequest : PaginationFilter, IRequest<PaginationResponse<CommentDto>>
{
    public Guid EventId { get; set; }
}

public class SearchAllCommentsByEventRequestHandler : IRequestHandler<SearchAllCommentsByEventRequest, PaginationResponse<CommentDto>>
{
    private readonly IReadRepository<Comment> _repository;

    public SearchAllCommentsByEventRequestHandler(IReadRepository<Comment> repository) => _repository = repository;

    public async Task<PaginationResponse<CommentDto>> Handle(SearchAllCommentsByEventRequest request, CancellationToken cancellationToken)
    {
        var spec = new CommentsBySearchRequestWithEventSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}
public class CommentsBySearchRequestWithEventSpec : EntitiesByPaginationFilterSpec<Comment, CommentDto>
{
    public CommentsBySearchRequestWithEventSpec(SearchAllCommentsByEventRequest request)
        : base(request) =>
        Query
            .Include(c => c.Responses)
            .OrderBy(c => c.CreatedOn, !request.HasOrderBy());
}
