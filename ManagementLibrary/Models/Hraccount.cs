using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ManagementLibrary.Models
{
    public partial class Hraccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        [Required(ErrorMessage ="Role is required")]
        [Range(1, 3, ErrorMessage = "Invalid Role")]
        public int? MemberRole { get; set; }
    }
}
