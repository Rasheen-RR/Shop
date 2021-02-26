using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Contexts;
using Shop.Models;

namespace Shop.Pages.Admin.Product
{
    public class CreateModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public CreateModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["categoryID"] = new SelectList(_context.categories, "categoryID", "categoryID");
        ViewData["supplierID"] = new SelectList(_context.suppliers, "supplierID", "supplierID");
            return Page();
        }

        [BindProperty]
        public Products Products { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.products.Add(Products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
