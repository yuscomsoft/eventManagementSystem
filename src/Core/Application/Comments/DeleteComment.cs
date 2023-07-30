using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Comments;
public class DeleteCommentRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCommentRequest(Guid id) => Id = id;
}

public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, Guid>
{
    private readonly IRepository<Comment> _repository;
    private readonly IStringLocalizer _t;

    public DeleteCommentRequestHandler(IRepository<Comment> repository, IStringLocalizer<DeleteCommentRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = comment ?? throw new NotFoundException(_t["Product {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        comment.DomainEvents.Add(EntityDeletedEvent.WithEntity(comment));

        await _repository.DeleteAsync(comment, cancellationToken);

        return request.Id;
    }
}