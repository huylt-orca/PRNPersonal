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
    public class DeleteModel : PageModel
    {
        private CandidateProfileRepository repository;

        public DeleteModel()
        {
            repository = new CandidateProfileRepository();
        }

        [BindProperty]
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

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool result = repository.Delete(id);

            if (result)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
