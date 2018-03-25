using System;
using System.Collections.Generic;
using System.Linq;
using FiiPrezent.Controllers;

namespace FiiPrezent.Services
{
    public class EventsService
    {
        private static readonly List<Event> _events = new List<Event>
        {
            new Event
            {
                Name = "Best training ever",
                Description = "Modern web application development with ASP.NET Core :o",
                VerificationCode = "cometothedarksidewehavecookies"
            }
        };

        public Event RegisterParticipant(string verificationCode, string participantName)
        {
            var @event = FindEventByVerificationCode(verificationCode);
            @event?.RegisterParticipant(participantName);

            return @event;
        }

        public Event FindEventByVerificationCode(string modelCode)
        {
            return _events.SingleOrDefault(x => x.VerificationCode == modelCode);
        }

        public Event FindEventById(Guid id)
        {
            return _events.Single(x => x.Id == id);
        }
    }
}
