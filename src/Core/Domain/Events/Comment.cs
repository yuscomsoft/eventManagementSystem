namespace EventManagment.Domain.Events;
public class Comment : AuditableEntity, IAggregateRoot
{
    public Guid EventId { get; set; }
    public string Text { get; set; } = default!;
    public Guid ParticipantId { get; set; }
    public bool IsActive { get; set; }
    public ICollection<CommentResponse> Responses { get; set; } = new HashSet<CommentResponse>();

    public Comment(Guid eventId, string text)
    {
        EventId = eventId;
        Text = text;
    }

    public Comment Update(string text)
    {
        if (text is not null && Text?.Equals(text) is not true) Text = text;
        return this;
    }
}
