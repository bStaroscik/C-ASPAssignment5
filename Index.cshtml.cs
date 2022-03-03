using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4
{
    public class IndexModel : PageModel
    {
        private readonly Assignment4.Data.Assignment4DbContext _context;

        public IndexModel(Assignment4.Data.Assignment4DbContext context)
        {
            _context = context;
        }

        public IList<FuelCalcItem> FuelCalcItem { get;set; }

        public async Task OnGetAsync()
        {
            FuelCalcItem = await _context.FuelCalcItem.ToListAsync();
        }
    }
}
