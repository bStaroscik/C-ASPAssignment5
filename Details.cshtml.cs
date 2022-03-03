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
    public class DetailsModel : PageModel
    {
        private readonly Assignment4.Data.Assignment4DbContext _context;

        public DetailsModel(Assignment4.Data.Assignment4DbContext context)
        {
            _context = context;
        }

        public FuelCalcItem FuelCalcItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FuelCalcItem = await _context.FuelCalcItem.FirstOrDefaultAsync(m => m.Id == id);

            if (FuelCalcItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
