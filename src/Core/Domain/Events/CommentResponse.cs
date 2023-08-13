using EventManagment.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagment.Domain.Events;
public class CommentResponse : AuditableEntity, IAggregateRoot
{
    public Guid CommentId { get; set; }
    public Comment Comment { get; set; }
    public string Response { get; set; } = default!;

    public CommentResponse()
    {
        // Only needed for working with dapper (See GetCommentResponseViaDapperRequest)
        // If you're not using dapper it's better to remove this constructor.
    }

    public CommentResponse(Guid commentId, string response)
    {
        CommentId = commentId;
        Response = response;
    }

    public CommentResponse Update(string? response)
    {
        if (response is not null && Response?.Equals(response) is not true) Response = response;
        return this;
    }
}


