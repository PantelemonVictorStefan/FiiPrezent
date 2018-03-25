using System;
using System.Collections.Generic;
using System.Linq;
using FiiPrezent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FiiPrezent.Controllers
{
    public class HomeController : Controller
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

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RsvpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // if code is valid
            var training = _events.SingleOrDefault(x => x.VerificationCode == model.Code);
            if (training == null)
            {
                ModelState.AddModelError<RsvpViewModel>(x => x.Code, "Wrong verification code");
                return View(model);
            }

            training.RegisterParticipant(model.Name);

            return RedirectToAction("Event", new
            {
                Id = training.Id
            });
        }

        public IActionResult Event(string id)
        {
            Guid guid = Guid.Parse(id);
            Event @event = _events.Single(x => x.Id == guid);
            return View(new EventViewModel(@event));
        }


    }

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
