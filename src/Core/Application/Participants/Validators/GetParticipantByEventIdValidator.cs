/*using EventManagment.Application.Catalog.Products;
using EventManagment.Application.Participants.Specifications;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants.Validators;
public class GetParticipantByEventIdValidator : CustomValidator<GetParticipantByEventIdRequest>
{
    public GetParticipantByEventIdValidator(IReadRepository<Participant> participantRepo, IReadRepository<Event> brandRepo, IStringLocalizer<CreateProductRequestValidator> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await productRepo.FirstOrDefaultAsync(new GetParticipantByEventIdSpec(name), ct) is null)
                .WithMessage((_, name) => T["Product {0} already Exists.", name]);

        RuleFor(p => p.Rate)
            .GreaterThanOrEqualTo(1);

        RuleFor(p => p.Image);

        RuleFor(p => p.ParticipantId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await participantRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["ParticipantId with Id {0} Not Found.", id]);
    }
}*/