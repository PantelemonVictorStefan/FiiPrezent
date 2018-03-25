using FiiPrezent.Controllers;

namespace FiiPrezent.Models
{
    public class EventViewModel
    {
        public EventViewModel(Event @event)
        {
            Name = @event.Name;
            Description = @event.Description;
            Participants = @event.Participants;
        }

        public string Name { get; }
        public string Description { get; }
        public string[] Participants { get; }
    }
}