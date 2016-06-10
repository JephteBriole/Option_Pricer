using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PricerWebClient.PricerService;
using System.Threading.Tasks;

namespace PricerWebClient.Controllers
{
    public class HomeController : Controller
    {
        private ServiceClient _client = new ServiceClient();

        public ActionResult Index()
        {
            Option option = new Option
            {
                Maturity = 1,
                RiskFreeInterestRate = 0.05,
                Strike = 148,
                UnderlyingPrice = 150,
                Volatility = 0.1,
                NbrOfSimulations = 100000
            };

            option.CallPrice = new Price();
            option.PutPrice = new Price();
            option.Error = new ErrorType();

            return View(option);
        }

        [HttpPost]
        public async Task<ActionResult> CalculatePrice(Option formOption)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            
            formOption.CallPrice = new Price();
            formOption.PutPrice = new Price();
            formOption.Error = new ErrorType();

            d1 = (Math.Log(formOption.UnderlyingPrice / formOption.Strike) + (formOption.RiskFreeInterestRate + formOption.Volatility * formOption.Volatility / 2.0) * formOption.Maturity) / (formOption.Volatility * Math.Sqrt(formOption.Maturity));
            d2 = d1 - formOption.Volatility * Math.Sqrt(formOption.Maturity);

            formOption = await this._client.MonteCarloModelAsync(formOption);
            formOption = await this._client.BlackScholesModelAsync(d1, d2, formOption);
            
            // Output Formatting
            formOption = this.ComputeErrorType(formOption);
            formOption = this.GetRoundedOption(formOption);

            return View("Index", formOption);
        }
        /*//[HttpPost]
        public ActionResult CalculatePrice(Option formOption)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            formOption.CallPrice = new Price();
            formOption.PutPrice = new Price();
            formOption.Error = new ErrorType();

            d1 = (Math.Log(formOption.UnderlyingPrice / formOption.Strike) + (formOption.RiskFreeInterestRate + formOption.Volatility * formOption.Volatility / 2.0) * formOption.Maturity) / (formOption.Volatility * Math.Sqrt(formOption.Maturity));
            d2 = d1 - formOption.Volatility * Math.Sqrt(formOption.Maturity);

            formOption = this._client.MonteCarloModel(formOption);
            formOption = this._client.BlackScholesModel(d1, d2, formOption);
            formOption = this.ComputeErrorType(formOption);
            formOption = this.GetRoundedOption(formOption);

            return View("Index", formOption);
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private Option ComputeErrorType(Option formOption)
        {
            formOption.Error.Call = (formOption.CallPrice.MC != null && formOption.CallPrice.BS != null) ? (double?)Math.Round((double)(formOption.CallPrice.BS != 0 ? (formOption.CallPrice.MC - formOption.CallPrice.BS) / formOption.CallPrice.BS : 0), 4) : null;
            formOption.Error.Put = (formOption.PutPrice.MC != null && formOption.PutPrice.BS != null) ? (double?)Math.Round((double)(formOption.PutPrice.BS != 0 ? (formOption.PutPrice.MC - formOption.PutPrice.BS) / formOption.PutPrice.BS : 0), 4) : null;

            return formOption;
        }

        private Option GetRoundedOption(Option formOption)
        {
            formOption.CallPrice.BS = Math.Round((double)formOption.CallPrice.BS, 4);
            formOption.PutPrice.BS = Math.Round((double)formOption.PutPrice.BS, 4);
            formOption.CallPrice.MC = Math.Round((double)formOption.CallPrice.MC, 4);
            formOption.PutPrice.MC = Math.Round((double)formOption.PutPrice.MC, 4);

            return formOption;
        }
    }
}