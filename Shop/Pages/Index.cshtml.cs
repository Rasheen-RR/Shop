using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Contexts;
using Shop.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NorthWindContext _context;

        public IList<Products> Products { get; set; }


        public IndexModel(ILogger<IndexModel> logger, NorthWindContext ctx)
        {
            _context = ctx;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            Products = await _context.products
                .Include(p => p.categories)
                .Include(p => p.suppliers).ToListAsync();
        }
    }
}
