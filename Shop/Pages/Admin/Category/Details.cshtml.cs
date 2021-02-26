using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Contexts;
using Shop.Models;

namespace Shop.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public DetailsModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

        public Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories = await _context.categories.FirstOrDefaultAsync(m => m.categoryID == id);

            if (Categories == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
