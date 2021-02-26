using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Contexts;
using Shop.Models;

namespace Shop.Pages.Admin.Product
{
    public class EditModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public EditModel(Shop.Contexts.NorthWindContext context)
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
           ViewData["categoryID"] = new SelectList(_context.categories, "categoryID", "categoryID");
           ViewData["supplierID"] = new SelectList(_context.suppliers, "supplierID", "supplierID");
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

            _context.Attach(Products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(Products.productID))
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

        private bool ProductsExists(int id)
        {
            return _context.products.Any(e => e.productID == id);
        }
    }
}
