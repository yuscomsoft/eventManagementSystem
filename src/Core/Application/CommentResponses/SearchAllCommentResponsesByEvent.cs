using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;
using Mapster;

namespace EventManagment.Application.CommentResponses
{
    public class SearchAllCommentResponsesByEventRequest : PaginationFilter, IRequest<PaginationResponse<CommentResponseDto>>
    {
        public Guid CommentId { get; set; }
    }

    public class SearchAllCommentResponsesByEventRequestHandler : IRequestHandler<SearchAllCommentResponsesByEventRequest, PaginationResponse<CommentResponseDto>>
    {
        private readonly IReadRepository<CommentResponse> _repository;

        public SearchAllCommentResponsesByEventRequestHandler(IReadRepository<CommentResponse> repository) => _repository = repository;

        public async Task<PaginationResponse<CommentResponseDto>> Handle(SearchAllCommentResponsesByEventRequest request, CancellationToken cancellationToken)
        {
            var spec = new CommentResponseBySearchRequestWithEventSpec(request);
            return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
        }
    }
    public class CommentResponseBySearchRequestWithEventSpec : EntitiesByPaginationFilterSpec<CommentResponse, CommentResponseDto>
    {
        public CommentResponseBySearchRequestWithEventSpec(SearchAllCommentResponsesByEventRequest request)
            : base(request) =>
            Query
                .Include(r => r.Comment)
                .OrderBy(r => r.CreatedOn, !request.HasOrderBy());
    }

}
