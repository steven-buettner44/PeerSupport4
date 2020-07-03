using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeerSupport4.Data;
using PeerSupport4.Models;

namespace PeerSupport4
{
    public class CreateModel : PageModel
    {
        public float GrandForksTotalHours;
     /*   public void OnPost()
        {
            if(Support.City=="Grand Forks")
            {
                GrandForksTotalHours += Support.Hours;
            }
            Support.TotalHours = GrandForksTotalHours;
        }
        */
        private readonly PeerSupport4.Data.PeerSupport4Context _context;

        public CreateModel(PeerSupport4.Data.PeerSupport4Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Support Support { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        
        public async Task<IActionResult> OnPostAsync()
        {
           
            

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Support.Add(Support);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    
    }
}
