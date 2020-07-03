using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeerSupport4.Data;
using PeerSupport4.Models;

namespace PeerSupport4
{
    public class DetailsModel : PageModel
    {
        private readonly PeerSupport4.Data.PeerSupport4Context _context;

        public DetailsModel(PeerSupport4.Data.PeerSupport4Context context)
        {
            _context = context;
        }

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
    }
}
