using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementLibrary.Models;
using ManagementLibrary.Repository;
using ManagementRazorPage.Model;

namespace ManagementRazorPage.Pages.CandidatePage
{
    public class IndexModel : PageModel
    {
        private CandidateProfileRepository repository;

        public IndexModel()
        {
            repository = new CandidateProfileRepository();
        }

        public int page { get; set; } = 1;

        private int PageSize { get; set; } = 3;
        public int totalPage { get; set; }
        public IList<CandidateProfile> CandidateProfile { get;set; }

       
        public string name { get; set; }

        public DateTime birthday { get;set;}

        public IActionResult OnGet(int pg =1)
        {
            string input1 = Request.Query["name"];
            string input2 = Request.Query["birthday"];
            name = input1 ?? "" ;
            page = pg;
            int allRecords = repository.GetTotal();

            totalPage = (int)Math.Floor((decimal)allRecords / PageSize);
            
            CandidateProfile = (IList<CandidateProfile>)repository.GetAll(pageSize: PageSize, page: page, name: name);
           
           
            return Page();
        }

        public IActionResult PageHandler(int pg)
        {
            page = pg;
            CandidateProfile = (IList<CandidateProfile>)repository.GetAll(pageSize: PageSize, page: page);
            
            return Page();
        }



    }
}
