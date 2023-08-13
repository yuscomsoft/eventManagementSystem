using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;

namespace EventManagment.Application.CommentResponses
{
    public class CreateCommentResponceRequest : IRequest<Guid>
    {
        public Guid CommentId { get; set; } = default!;
        public string Responce { get; set; } = default!;
    }

    public class CreateCommentResponceRequestHandler : IRequestHandler<CreateCommentResponceRequest, Guid>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IFileStorageService _file;
        public CreateCommentResponceRequestHandler(IRepository<Comment> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);
        public async Task<Guid> Handle(CreateCommentResponceRequest request, CancellationToken cancellationToken)
        {

            var commentResponce = new Comment(request.CommentId, request.Responce);
             
            // Add Domain Events to be raised after the commit
            commentResponce.DomainEvents.Add(EntityCreatedEvent.WithEntity(commentResponce));

            await _repository.AddAsync(commentResponce, cancellationToken);

            return commentResponce.Id;
        }

    }
}
