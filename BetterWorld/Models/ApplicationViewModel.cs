using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetterWorld.Models
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Upload CV")]
        [NotMapped] // Add this attribute
        public IFormFile CVFile { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string CVFileName { get; set; }
        public string CVContentType { get; set; }

    }
}