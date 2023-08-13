using EventManagment.Application.Catalog.Products;
using EventManagment.Application.Participants.Specifications;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants.Validators;
public class GetParticipantByEventIdValidator : CustomValidator<GetParticipantByEventIdRequest>
{
    public GetParticipantByEventIdValidator(IReadRepository<Participant> participantRepo, IReadRepository<Event> brandRepo, IStringLocalizer<CreateParticipantRequestValidator> T)
    {
        RuleFor(p => p.ParticipantId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await participantRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["ParticipantId with Id {0} Not Found.", id]);
    }
}