using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WEBSITES.Models
{
    public class User: IdentityUser
    {
        [Required]
        public int Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? PostalCode { get; set; }

    }
}
