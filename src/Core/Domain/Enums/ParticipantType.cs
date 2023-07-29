using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Domain.Events;
public enum ParticipantType
{
    [Description(nameof(Member))]
    Member = 1,

    [Description(nameof(Guest))]
    Guest
}
