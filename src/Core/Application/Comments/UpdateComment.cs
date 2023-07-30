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
    public class UpdateCommentRequest : IRequest<Guid>
    {
        public Guid EventId { get; set; }
        public string Text { get; set; } = default!;
    }

    public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, Guid>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IStringLocalizer _t;
        private readonly IFileStorageService _file;

        public UpdateCommentRequestHandler(IRepository<Comment> repository, IStringLocalizer<UpdateProductRequestHandler> localizer, IFileStorageService file) =>
            (_repository, _t, _file) = (repository, localizer, file);

        public async Task<Guid> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.EventId, cancellationToken);

            _ = comment ?? throw new NotFoundException(_t["Product {0} Not Found.", request.EventId]);

            var updateComment = comment.Update(request.Text);

            // Add Domain Events to be raised after the commit
            comment.DomainEvents.Add(EntityUpdatedEvent.WithEntity(comment));

            await _repository.UpdateAsync(updateComment, cancellationToken);

            return comment.Id;
        }
    }

}

