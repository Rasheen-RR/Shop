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

namespace Shop.Pages.Admin.Shipper
{
    public class EditModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public EditModel(Shop.Contexts.NorthWindContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shippers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippersExists(Shippers.shipperID))
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

        private bool ShippersExists(int id)
        {
            return _context.shippers.Any(e => e.shipperID == id);
        }
    }
}
