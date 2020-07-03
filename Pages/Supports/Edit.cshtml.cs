using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeerSupport4.Data;
using PeerSupport4.Models;

namespace PeerSupport4
{
    public class EditModel : PageModel
    {
        private readonly PeerSupport4.Data.PeerSupport4Context _context;

        public EditModel(PeerSupport4.Data.PeerSupport4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Support Support { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Support = await _context.Support.FirstOrDefaultAsync(m => m.ID == id);

            if (Support == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Support).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportExists(Support.ID))
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

        private bool SupportExists(int id)
        {
            return _context.Support.Any(e => e.ID == id);
        }
    }
}
