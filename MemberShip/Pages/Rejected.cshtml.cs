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
    public class RejectedModel : PageModel
    {
        private readonly MemberShip.Data.ApplicationDbContext _context;

        public RejectedModel(MemberShip.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        public async Task OnGetAsync()
        {
            Member = await _context.Members
                .Where(e => e.Rejected==true)
                .OrderByDescending(e => e.DateCreated)
                .ToListAsync();
        }
    }
}
