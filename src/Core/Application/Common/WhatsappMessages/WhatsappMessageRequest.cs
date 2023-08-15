using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Common.WhatsappMessages;
public class WhatsappMessageRequest
{
    public string RecipientNumber { get; set; } = default!;
    public string MessageBody { get; set; } = default!;
}
