using System.ComponentModel;

namespace EventManagment.Domain.Enums;
public enum EventType
{
    [Description(nameof(Virtual))]
    Virtual = 1,

    [Description(nameof(Physical))]
    Physical
}
