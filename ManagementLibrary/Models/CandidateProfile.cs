using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ManagementLibrary.Models
{
    public partial class CandidateProfile
    {
        [Required(ErrorMessage = "Id is required")]
        public string CandidateId { get; set; }
        [Required(ErrorMessage = "Fullname is required")]
        [RegularExpression(@"^(?=.{0,12}$)([A-Z][a-z]* ?)+$")]
        public string Fullname { get; set; }
        [Required(ErrorMessage ="Birthday is required")]
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage ="Description is required")]
        [StringLength(200,MinimumLength =12)]
        public string ProfileShortDescription { get; set; }

        [Required(ErrorMessage ="Url is required")]
        public string ProfileUrl { get; set; }

        [Required(ErrorMessage ="Posting Job is required")]
        public string PostingId { get; set; }

        public virtual JobPosting Posting { get; set; }
    }
}
