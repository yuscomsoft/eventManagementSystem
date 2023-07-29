using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Domain.Events;
public class CommentResponse : AuditableEntity
{
    public Guid CommentId { get; set; }
    public string Response { get; set; } = default!;
}
