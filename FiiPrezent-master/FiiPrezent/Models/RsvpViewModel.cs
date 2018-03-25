using System.ComponentModel.DataAnnotations;

namespace FiiPrezent.Models
{
    public class RsvpViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
    }
}