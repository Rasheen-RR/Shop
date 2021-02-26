using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Contexts;
using Shop.Models;

namespace Shop.Pages.Admin.Product
{
    public class DeleteModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public DeleteModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _context.products
                .Include(p => p.categories)
                .Include(p => p.suppliers).FirstOrDefaultAsync(m => m.productID == id);

            if (Products == null)
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

            Products = await _context.products.FindAsync(id);

            if (Products != null)
            {
                _context.products.Remove(Products);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
