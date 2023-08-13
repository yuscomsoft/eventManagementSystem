using EventManagment.Application.Catalog.Products;
using EventManagment.Application.Comments;
using EventManagment.Domain.Common.Events;
using EventManagment.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.CommentResponses
{
    public class UpdateCommentResponseRequest : IRequest<Guid>
    {
        public Guid CommentId { get; set; }
        public string Response { get; set; } = default!;
    }

    public class UpdateCommentResponseRequesttHandler : IRequestHandler<UpdateCommentResponseRequest, Guid>
    {
        private readonly IRepository<CommentResponse> _repository;
        private readonly IStringLocalizer _t;
        private readonly IFileStorageService _file;

        public UpdateCommentResponseRequesttHandler(IRepository<CommentResponse> repository, IStringLocalizer<UpdateCommentResponseRequesttHandler> localizer, IFileStorageService file) =>
            (_repository, _t, _file) = (repository, localizer, file);

        public async Task<Guid> Handle(UpdateCommentResponseRequest request, CancellationToken cancellationToken)
        {
            var commentResponse = await _repository.GetByIdAsync(request.CommentId, cancellationToken);

            _ = commentResponse ?? throw new NotFoundException(_t["Product {0} Not Found.", request.CommentId]);

            var updateCommentResponse = commentResponse.Update(request.Response);

            // Add Domain Events to be raised after the commit
            commentResponse.DomainEvents.Add(EntityUpdatedEvent.WithEntity(commentResponse));

            await _repository.UpdateAsync(updateCommentResponse, cancellationToken);

            return commentResponse.Id;
        }
    }
}
