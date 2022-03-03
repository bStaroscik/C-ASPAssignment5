using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4
{
    public class CreateModel : PageModel
    {
        private readonly Assignment4.Data.Assignment4DbContext _context;

        public CreateModel(Assignment4.Data.Assignment4DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FuelCalcItem FuelCalcItem { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FuelCalcItem.Add(FuelCalcItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
