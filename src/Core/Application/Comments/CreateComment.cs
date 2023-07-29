using EventManagment.Application.Catalog.Products;
using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Comments
{
    public class CreateCommentRequest : IRequest<Guid>
    {
        public Guid EventId { get; set; } = default!;
        public string Text { get; set; } = default!;
    }

    public class CreateCommentRequestHandler :IRequestHandler<CreateCommentRequest, Guid>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IFileStorageService _file;
        public CreateCommentRequestHandler(IRepository<Comment> repository, IFileStorageService file) =>
        (_repository, _file) = (repository, file);
        public async Task<Guid> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {

            var comment = new Comment(request.EventId, request.Text);

            // Add Domain Events to be raised after the commit
            comment.DomainEvents.Add(EntityCreatedEvent.WithEntity(comment));

            await _repository.AddAsync(comment, cancellationToken);

            return comment.Id;
        }

    }

}
