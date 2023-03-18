using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagementLibrary.Models;
using ManagementLibrary.Repository;

namespace ManagementRazorPage.Pages.CandidatePage
{
    public class CreateModel : PageModel
    {
        private CandidateProfileRepository repository;
        private JobPostingRepository jobRepo;
        public String msg { get; set; }
        public CreateModel()
        {
           repository = new CandidateProfileRepository();
            jobRepo = new JobPostingRepository();
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(jobRepo.GetAll, "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (repository.Create(CandidateProfile))
            {
                return RedirectToPage("./Index");
            }
            msg = "Create Failed! Duplicate Id";
            // hander add failed
            ViewData["PostingId"] = new SelectList(jobRepo.GetAll, "PostingId", "JobPostingTitle");
            return Page();
        }
    }
}
