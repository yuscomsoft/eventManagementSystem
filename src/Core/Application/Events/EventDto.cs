using EventManagment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Events;
public class EventDto : IDto
{
    public Guid Id { get; set; } = default!;
    public string EventName { get; set; } = default!;
    public string? Image { get; set; }
    public DateTime StartingDate { get; set; } = default!;
    public DateTime EndingDate { get; set; } = default!;
    public int EventYear { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Status { get; set; } = default!;
   // public Guid EventSettingId { get; set; }
}
