using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemberShip.Data;
using Membership.Models;
using Membership.Enums;

namespace MemberShip.Pages
{
    public class EditModel : PageModel
    {
        private readonly MemberShip.Data.ApplicationDbContext _context;

        public EditModel(MemberShip.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Members.FirstOrDefaultAsync(m => m.ID == id);

            if (Member == null)
            {
                return NotFound();
            }

            var enumData = from Salutation e in Enum.GetValues(typeof(Salutation))
                           select new
                           {
                               ID = (int)e,
                               Text = e.ToString()
                           };
            ViewData["Salutation"] = new SelectList(enumData, "Text", "Text", Member.Salutation);
            enumData = from Gender e in Enum.GetValues(typeof(Gender))
                           select new
                           {
                               ID = (int)e,
                               Text = e.ToString()
                           };
            ViewData["Gender"] = new SelectList(enumData, "Text", "Text", Member.Gender);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Member.Salutation = ((Salutation)int.Parse(Member.Salutation)).ToString();
            //Member.Gender = ((Gender)int.Parse(Member.Gender)).ToString();
            _context.Attach(Member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(Member.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemberExists(Guid id)
        {
            return _context.Members.Any(e => e.ID == id);
        }
    }
}
