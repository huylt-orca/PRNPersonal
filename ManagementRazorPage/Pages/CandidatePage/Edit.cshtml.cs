using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementLibrary.Models;
using ManagementLibrary.Repository;

namespace ManagementRazorPage.Pages.CandidatePage
{
    public class EditModel : PageModel
    {
        private CandidateProfileRepository repository;
        private JobPostingRepository jobRepo;

        public EditModel()
        {
            repository = new CandidateProfileRepository();
            jobRepo = new JobPostingRepository();
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
            ViewData["PostingId"] = new SelectList(jobRepo.GetAll, "PostingId", "JobPostingTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           if (repository.Update(CandidateProfile))
            {
                return RedirectToPage("./Index");
            }

           // hander update failed


            return Page();
        }
    }
}
