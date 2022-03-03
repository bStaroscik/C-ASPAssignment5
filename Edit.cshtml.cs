using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4
{
    public class EditModel : PageModel
    {
        private readonly Assignment4.Data.Assignment4DbContext _context;

        public EditModel(Assignment4.Data.Assignment4DbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FuelCalcItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelCalcItemExists(FuelCalcItem.Id))
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

        private bool FuelCalcItemExists(int id)
        {
            return _context.FuelCalcItem.Any(e => e.Id == id);
        }
    }
}
