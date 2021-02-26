using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Contexts;
using Shop.Models;

namespace Shop.Pages.Admin.Supplier
{
    public class DeleteModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public DeleteModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Suppliers Suppliers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Suppliers = await _context.suppliers.FirstOrDefaultAsync(m => m.supplierID == id);

            if (Suppliers == null)
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

            Suppliers = await _context.suppliers.FindAsync(id);

            if (Suppliers != null)
            {
                _context.suppliers.Remove(Suppliers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
