using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    public class FuelCalcItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Starting Odometer")]
        public int StartOdometer { get; set; }
        [Display(Name = "Ending Odometer")]
        public int EndOdometer { get; set; }
        [Display(Name = "Amount of Fuel (Gallons)")]
        public decimal AmountOfFuel { get; set; }
        [Display(Name = "Cost of Fuel")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal CostOfFuel { get; set; }

        private decimal fuelMPG;
        [Display(Name = "Miles per Gallon")]
        public decimal FuelMPG
        {
            get => (EndOdometer - StartOdometer) / AmountOfFuel;
        }

        private decimal costPerMile;
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Cost per Mile")]

        public decimal CostPerMile
        {
            get => CostOfFuel / FuelMPG;
        }
    }
}
