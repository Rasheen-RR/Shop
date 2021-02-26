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
    public class DetailsModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public DetailsModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

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
    }
}
