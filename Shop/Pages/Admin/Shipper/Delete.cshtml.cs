using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Contexts;
using Shop.Models;

namespace Shop.Pages.Admin.Shipper
{
    public class DeleteModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public DeleteModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shippers Shippers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shippers = await _context.shippers.FirstOrDefaultAsync(m => m.shipperID == id);

            if (Shippers == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shippers = await _context.shippers.FindAsync(id);

            if (Shippers != null)
            {
                _context.shippers.Remove(Shippers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
