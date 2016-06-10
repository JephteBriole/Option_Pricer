using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PricerWebClient.Models
{
    public class OptionInputViewModel
    {
        [Required]
        [RegularExpression(@"^[0-9]*(?:\,[0-9]*)?$", ErrorMessage = "Please enter a valid numeric type")]
        [Display(Name = "Spot S")]
        public double Spot { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*(?:\,[0-9]*)?$", ErrorMessage = "Please enter a valid numeric type")]
        [Display(Name = "Strike K")]
        public double Strike { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*(?:\,[0-9]*)?$", ErrorMessage = "Please enter a valid numeric type")]
        [Display(Name = "Volatility σ")]
        public double Volatility { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*(?:\,[0-9]*)?$", ErrorMessage = "Please enter a valid numeric type")]
        [Display(Name = "Risk-free interest rate r")]
        public double InterestRate { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*(?:\,[0-9]*)?$", ErrorMessage = "Please enter a valid numeric type")]
        [Display(Name = "Maturity")]
        public double Maturity { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter a valid integer type")]
        [Display(Name = "Number of simulations n")]
        public int NbrSimulations { get; set; }
    }

    public class ResultPriceViewModel
    {
        [Editable(false)]
        [Display(Name = "MC Price")]
        public double? Mc_CallPrice { get; set; }

        [Editable(false)]
        [Display(Name = "MC Price")]
        public double? Mc_PutPrice { get; set; }

        [Editable(false)]
        [Display(Name = "Black-Scholes Price")]
        public double? Bs_CallPrice { get; set; }

        [Editable(false)]
        [Display(Name = "MC Price")]
        public double? Bs_PutPrice { get; set; }

        [Editable(false)]
        [Display(Name = "Relative Error (MC%BS)")]
        public double? Error_CallPrice { get; set; }

        [Editable(false)]
        [Display(Name = "Relative Error (MC%BS)")]
        public double? Error_PutPrice { get; set; }
    }
}