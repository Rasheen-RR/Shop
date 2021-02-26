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
    public class DetailsModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public DetailsModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

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
    }
}
