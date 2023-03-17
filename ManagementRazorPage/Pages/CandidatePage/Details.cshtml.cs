using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementLibrary.Models;
using ManagementLibrary.Repository;

namespace ManagementRazorPage.Pages.CandidatePage
{
    public class DetailsModel : PageModel
    {
        private CandidateProfileRepository repository;

        public DetailsModel()
        {
            repository = new CandidateProfileRepository();
        }

        public CandidateProfile CandidateProfile { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = repository.GetById(id);

            if (CandidateProfile == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
