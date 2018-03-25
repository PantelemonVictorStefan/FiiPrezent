using System;
using System.Collections.Generic;

namespace FiiPrezent.Services
{
    public class Event
    {
        private readonly List<string> _participants = new List<string>();

        public Event()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VerificationCode { get; set; }
        public string[] Participants => _participants.ToArray();

        public void RegisterParticipant(string name)
        {
            _participants.Add(name);
        }

    }
}