using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BetterWorld.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }

    }
    public class UserProfileModel
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string Skills { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Bio { get; set; }
        //public List<UserViewModel> UserData { get; set; }
    }

    public class review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AccountType { get; set; }
        [Display(Name = "Upload Pic")]
        [NotMapped] // Add this attribute
        public IFormFile PicFile { get; set; }
        public string PicFileName { get; set; }
        public string PicContentType { get; set; }
        public int? Age { get; set; }
        public string Skills { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Bio { get; set; }

    }

}
