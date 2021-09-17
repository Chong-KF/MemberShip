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
    public class ListModel : PageModel
    {
        private readonly MemberShip.Data.ApplicationDbContext _context;

        public ListModel(MemberShip.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        public async Task OnGetAsync()
        {
            Member = await _context.Members.ToListAsync();
        }
    }
}
