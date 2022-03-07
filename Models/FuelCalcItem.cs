using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    public class FuelCalcItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a Starting Odometer")]
        [Display(Name = "Starting Odometer")]
        public int StartOdometer { get; set; }
        [Required(ErrorMessage = "You must enter an Ending Odometer")]
        [Display(Name = "Ending Odometer")]
        public int EndOdometer { get; set; }
        [Required(ErrorMessage = "You must enter a value")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Amount of Fuel (Gallons)")]
        public decimal AmountOfFuel { get; set; }
        [Required(ErrorMessage = "You must enter a value")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Cost of Fuel")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal CostOfFuel { get; set; }

        
        public decimal CalcMilesPerGallon()
        {
            decimal mpg = (EndOdometer - StartOdometer) / AmountOfFuel;

            return mpg;
        }

        public decimal CalcCostPerMile()
        {
            decimal cpm = CostOfFuel / CalcMilesPerGallon();

            return cpm;
        }
    }
}
