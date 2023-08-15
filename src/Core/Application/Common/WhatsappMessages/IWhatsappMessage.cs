using EventManagment.Application.Common.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Common.WhatsappMessages;
public interface IWhatsappMessage : ITransientService
{
    Task SendAsync(WhatsappMessageRequest request, CancellationToken ct = default);
}
