using EventManagment.Application.Participants.Specifications;
using EventManagment.Domain.Events;

namespace EventManagment.Application.Participants.Validators;

public class CreateParticipantRequestValidator : CustomValidator<CreateParticipantRequest>
{
    public CreateParticipantRequestValidator(IReadRepository<Participant> participantRepo, IReadRepository<Event> eventRepo, IStringLocalizer<CreateParticipantRequestValidator> T)
    {
        RuleFor(p => p.MemberNumber)
            .NotEmpty()
            .MaximumLength(10)
            .MustAsync(async (name, ct) => await participantRepo.FirstOrDefaultAsync(new ParticipantByMemberNumberSpec(name), ct) is null)
                .WithMessage((_, name) => T["Member {0} already Exists.", name]);

        RuleFor(p => p.EventId)
            .NotEmpty()
            .MustAsync(async (id, ct) => await eventRepo.GetByIdAsync(id, ct) is not null)
                .WithMessage((_, id) => T["Event {0} Not Found.", id]);
    }
}