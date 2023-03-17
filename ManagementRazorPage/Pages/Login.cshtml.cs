using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagementLibrary.Models;
using ManagementLibrary.Repository;
using ManagementRazorPage.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ManagementRazorPage.Pages
{
    public class LoginModel : PageModel
    {
        private HraccountRepository repository;

        public LoginModel()
        {
            repository = new HraccountRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public String msgError { get; set; }

        [BindProperty]
        public Account Account { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Hraccount hraccount = repository.checkAccount(Account.Email,Account.Password);
            if (hraccount == null)
            {
                msgError = "You are not allowed to do this function!";
                return Page();
            }
            //HttpContext.Session.SetString("UserName", "John Doe");
            //string userName = HttpContext.Session.GetString("UserName");
            //HttpContext.Session.Remove("UserName");

            //HttpContext.Session.SetString("ACCOUNT_STAFF", JsonConvert.SerializeObject(accountStaff));
            //var AccountSession = JsonConvert.DeserializeObject<StaffAccount>(HttpContext.Session.GetString("ACCOUNT_STAFF"));
            //HttpContext.Session.Remove("ACCOUNT_STAFF");

            String url = "/Login";
            switch (hraccount.MemberRole)
            {
                case 1:
                    url = "./CandidatePage/Index";
                    break;
                case 2:
                    msgError = "You are not allowed to do this function!";
                    return Page();
                    break;
                case 3:
                    msgError = "You are not allowed to do this function!";
                    return Page();
                    break;
                default:
                    msgError = "You are not allowed to do this function!";
                    return Page();
            }


            return RedirectToPage(url);
        }
    }
}
