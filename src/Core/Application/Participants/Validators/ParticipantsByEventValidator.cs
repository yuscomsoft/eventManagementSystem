using EventManagment.Application.Catalog.Products;
using EventManagment.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Participants.Validators;
public class ParticipantsByEventValidator : CustomValidator<GetParticipantsByEventRequest>
{
    public ParticipantsByEventValidator(IReadRepository<Event> eventRepo,  IStringLocalizer<CreateParticipantRequestValidator> T)
    {
        RuleFor(p => p.EventId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await eventRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Event with Id {0} Not Found.", id]);
    }
}