using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagment.Domain.Enums;

namespace EventManagment.Domain.Events;
public class Event : AuditableEntity
{
    public string EventName { get; set; } = default!;
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public int EventYear { get; set; }
    public string Location { get; set; } = default!;
    public EventStatus Status { get; set; }
    public ICollection<Participant> Participants { get; set; } = new HashSet<Participant>();
    public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
}
