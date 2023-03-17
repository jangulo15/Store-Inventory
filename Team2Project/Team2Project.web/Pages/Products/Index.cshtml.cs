using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Team2Project.web.Data;
using Team2Project.web.Models;

namespace Team2Project.web.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }

        public IList<Product> Products { get;set; }

        public async Task OnGetAsync(string searchCategory)
        {
            CurrentFilter = searchCategory;
            IQueryable<Product> productCategory = from p in _context.Product select p;
            if (!String.IsNullOrEmpty(searchCategory))
            {
                productCategory = productCategory.Where(x => x.Category.Contains(searchCategory));
            }
            //if (_context.Product != null)
            //{
            //    Product = await _context.Product.ToListAsync();
            //}
            Products = await productCategory.ToListAsync();
        }
    }
}
