using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MemberShip.Data;
using Membership.Models;

namespace MemberShip.Pages
{
    public class IndexModel : PageModel
    {        
        private readonly ApplicationDbContext _context;
        public IList<Member> Members;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //Members = _context.Members.ToList();
            if (!User.Identity.IsAuthenticated)           
            {
                 return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            return Page() ;
        }
    }
}
