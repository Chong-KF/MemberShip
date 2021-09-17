using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MemberShip.Data;
using Membership.Models;

namespace MemberShip.Pages
{
    public class ApprovedModel : PageModel
    {
        private readonly MemberShip.Data.ApplicationDbContext _context;

        public ApprovedModel(MemberShip.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        public async Task OnGetAsync()
        {
            Member = await _context.Members
                .Where(e => (e.Rejected == false) && (!String.IsNullOrEmpty(e.MemberShipID)))
                .OrderByDescending(e => e.DateCreated)
                .ToListAsync();
        }
    }
}
