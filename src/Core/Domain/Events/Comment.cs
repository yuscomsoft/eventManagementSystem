using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Domain.Events;
public class Comment : AuditableEntity
{
    public Guid EventId { get; set; }
    public string Text { get; set; } = default!;
    public Guid ParticipantId { get; set; }
    public bool IsActive { get; set; }
    public ICollection<CommentResponse> Responses { get; set; } = new HashSet<CommentResponse>();
}
