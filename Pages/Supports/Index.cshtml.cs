using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeerSupport4.Data;
using PeerSupport4.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
    
namespace PeerSupport4
{
    
    public class IndexModel : PageModel
    {
        private readonly PeerSupport4.Data.PeerSupport4Context _context;

        public IndexModel(PeerSupport4.Data.PeerSupport4Context context)
        {
            _context = context;
        }

        public IList<Support> Support { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Cities { get; set; }
        

        public async Task OnGetAsync()
        {
            Support = await _context.Support.ToListAsync();
            var cities = from m in _context.Support
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                cities = cities.Where(s => s.City.Contains(SearchString));
            }
            Support = await cities.ToListAsync();
        }
    }
}
