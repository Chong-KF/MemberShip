using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MemberShip.Data;
using Membership.Models;
using Membership.Enums;

namespace MemberShip.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MemberShip.Data.ApplicationDbContext _context;

        public CreateModel(MemberShip.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Member.Salutation = ((Salutation)int.Parse(Member.Salutation)).ToString();
            Member.Gender = ((Gender)int.Parse(Member.Gender)).ToString();
            Member.DateCreated = DateTime.Now;
            _context.Members.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
