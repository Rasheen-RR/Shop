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
    public class IndexModel : PageModel
    {
        private readonly Shop.Contexts.NorthWindContext _context;

        public IndexModel(Shop.Contexts.NorthWindContext context)
        {
            _context = context;
        }

        public IList<Categories> Categories { get;set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.categories.ToListAsync();
        }
    }
}
