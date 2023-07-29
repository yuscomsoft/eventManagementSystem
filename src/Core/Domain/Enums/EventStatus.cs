using System.ComponentModel;

namespace EventManagment.Domain.Enums;
public enum EventStatus
{
    [Description(nameof(Upcoming))]
    Upcoming = 1,

    [Description(nameof(InProgress))]
    InProgress,

    [Description(nameof(Postponed))]
    Postponed,

    [Description(nameof(Cancelled))]
    Cancelled,

    [Description(nameof(Completed))]
    Completed
}
