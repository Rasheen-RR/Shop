using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Contexts;
using Shop.Models;

namespace Shop.Pages.Admin.Supplier
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
            return Page();
        }

        [BindProperty]
        public Suppliers Suppliers { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.suppliers.Add(Suppliers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
