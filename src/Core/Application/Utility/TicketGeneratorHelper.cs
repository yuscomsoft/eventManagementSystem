using EventManagment.Application.DTOs;
using EventManagment.Domain.Events;

namespace EventManagment.Infrastructure.Utility;
public static class TicketGeneratorHelper
{
    /// <summary>
    /// Generates an event ticket number based on the event and participants.
    /// </summary>
    /// <param name="event">The event details.</param>
    /// <param name="participants">The list of participants to get the last ticket number.</param>
    /// <returns>The generated event ticket number.</returns>
    public static string GenerateEventTicketAsync(Event @event, List<ParticipantDto> participants)
    {
        // Check if there are no participants
        if (!participants.Any())
        {
            // If no participants, generate a ticket number with the starting index of 00001
            return $"{@event.EventName[..2].ToUpper()}/{@event.EventYear}/00001";
        }

        // Get the last participant's registration number
        var lastParticipant = participants.Last();
        // Extract the last registration number index and parse it as an integer
        var lastRegistrationNumberIndex = int.Parse(lastParticipant.EventRegistrationNumber.Split('/').Last());
        // Calculate the next registration number index
        var nextRegistrationNumberIndex = lastRegistrationNumberIndex + 1;

        // Generate the ticket number with the next registration number index
        return $"{@event.EventName[..2].ToUpper()}/{@event.EventYear}/{nextRegistrationNumberIndex:00000}";

    }
}
