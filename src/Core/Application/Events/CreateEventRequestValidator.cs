using EventManagment.Application.Catalog.Products;
using EventManagment.Domain.Enums;
using EventManagment.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagment.Application.Events;
public class CreateEventRequestValidator : CustomValidator<CreateEventRequest>
{
    public CreateEventRequestValidator(IReadRepository<Event> eventRepo, IReadRepository<Brand> brandRepo, IStringLocalizer<CreateEventRequestValidator> T)
    {
        RuleFor(p => p.EventName)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (eventName, ct) => await eventRepo.FirstOrDefaultAsync(new EventByNameSpec(eventName), ct) is null)
                .WithMessage((_, eventName) => T["Event {0} already Exists.", eventName]);

        RuleFor(p => p.EndingDate)
            .GreaterThanOrEqualTo(p => p.StartingDate);

        RuleFor(p => p.EventYear)
          .GreaterThanOrEqualTo(DateTime.UtcNow.Year);

        RuleFor(p => p.Image);

        RuleFor(p => p.Location)
            .NotEmpty();
    }
}
