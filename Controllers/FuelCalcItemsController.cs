using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4.Controllers
{
    public class FuelCalcItemsController : Controller
    {
        private readonly Assignment4DbContext _context;

        public FuelCalcItemsController(Assignment4DbContext context)
        {
            _context = context;
        }

        // GET: FuelCalcItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelCalcItems.ToListAsync());
        }

        // GET: FuelCalcItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelCalcItem = await _context.FuelCalcItems
                .FirstOrDefaultAsync(m => m.Id == id);

            FuelCalcItemViewModel fuelCalcItemViewModel = new FuelCalcItemViewModel
            {
                Id = fuelCalcItem.Id,
                StartOdometer = fuelCalcItem.StartOdometer,
                EndOdometer = fuelCalcItem.EndOdometer,
                AmountOfFuel = fuelCalcItem.AmountOfFuel,
                CostOfFuel = fuelCalcItem.CostOfFuel
            };

            if (fuelCalcItem == null)
            {
                return NotFound();
            }

            return View(fuelCalcItemViewModel);
        }

        // GET: FuelCalcItems/Create
        public IActionResult Create()
        {
            var lastRecord = _context.FuelCalcItems.ToList().LastOrDefault();

            FuelCalcItem fuelCalcItem = new FuelCalcItem
            {
                StartOdometer = 0
            };

            if(lastRecord != null)
            {
                fuelCalcItem = new FuelCalcItem
                {
                    StartOdometer = lastRecord.EndOdometer,
                    EndOdometer = (lastRecord.EndOdometer) + 1
                };
            }


            return View(fuelCalcItem);
        }

        // POST: FuelCalcItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartOdometer,EndOdometer,AmountOfFuel,CostOfFuel")] FuelCalcItem fuelCalcItem)
        {
            if(fuelCalcItem.EndOdometer >= fuelCalcItem.StartOdometer)
            {
                if(fuelCalcItem.AmountOfFuel > 0)
                {
                    if(fuelCalcItem.CostOfFuel > 0)
                    {
                        if (ModelState.IsValid)
                        {
                            _context.Add(fuelCalcItem);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        return View(fuelCalcItem);
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(fuelCalcItem.CostOfFuel), "Cost must be greater than 0!");
                    }

                }
                else
                {
                    ModelState.AddModelError(nameof(fuelCalcItem.AmountOfFuel), "Amount of Fuel must be greater than 0!");
                }

            }
            else
            {
                ModelState.AddModelError(nameof(fuelCalcItem.EndOdometer), "Ending Odometer must be greater than the Starting!");
            }

            return View();
            
        }

        // GET: FuelCalcItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelCalcItem = await _context.FuelCalcItems.FindAsync(id);
            if (fuelCalcItem == null)
            {
                return NotFound();
            }
            return View(fuelCalcItem);
        }

        // POST: FuelCalcItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartOdometer,EndOdometer,AmountOfFuel,CostOfFuel")] FuelCalcItem fuelCalcItem)
        {
            if (id != fuelCalcItem.Id)
            {
                return NotFound();
            }
            if(fuelCalcItem.EndOdometer >= fuelCalcItem.StartOdometer)
            {
                if(fuelCalcItem.AmountOfFuel > 0)
                {
                    if(fuelCalcItem.CostOfFuel > 0)
                    {
                        if (ModelState.IsValid)
                        {
                            try
                            {
                                _context.Update(fuelCalcItem);
                                await _context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                if (!FuelCalcItemExists(fuelCalcItem.Id))
                                {
                                    return NotFound();
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            return RedirectToAction(nameof(Index));
                        }
                        return View(fuelCalcItem);
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(fuelCalcItem.CostOfFuel), "Cost of Fuel must be greater than 0!");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(fuelCalcItem.AmountOfFuel), "Amount of Fuel must be greater than 0!");
                }
            }
            else
            {
                ModelState.AddModelError(nameof(fuelCalcItem.EndOdometer), "Ending Odometer must be greater than the Starting!");
            }

            return View();
        }

        // GET: FuelCalcItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelCalcItem = await _context.FuelCalcItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelCalcItem == null)
            {
                return NotFound();
            }

            return View(fuelCalcItem);
        }

        // POST: FuelCalcItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelCalcItem = await _context.FuelCalcItems.FindAsync(id);
            _context.FuelCalcItems.Remove(fuelCalcItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelCalcItemExists(int id)
        {
            return _context.FuelCalcItems.Any(e => e.Id == id);
        }
    }
}
