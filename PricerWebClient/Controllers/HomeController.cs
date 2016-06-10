using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PricerWebClient.PricerService;
using System.Threading.Tasks;
using PricerWebClient.Models;

namespace PricerWebClient.Controllers
{
    public class HomeController : Controller
    {
        private ServiceClient _client = new ServiceClient();
        private OptionInputViewModel defaultInput = new OptionInputViewModel
        {
            Maturity = 1,
            InterestRate = 0.05,
            Strike = 148,
            Spot = 150,
            Volatility = 0.1,
            NbrSimulations = 100000
        };

        public ActionResult Index()
        {
            return View(defaultInput);
        }

        [HttpPost]
        public async Task<PartialViewResult> CalculatePrice(OptionInputViewModel formOptionInputViewModel)
        {
            double d1 = 0.0;
            double d2 = 0.0;

            /*Option formOption = new Option()
            {
                UnderlyingPrice = double.Parse(formOptionInputViewModel.Spot),
                Strike = double.Parse(formOptionInputViewModel.Strike),
                Maturity = double.Parse(formOptionInputViewModel.Maturity),
                Volatility = double.Parse(formOptionInputViewModel.Volatility),
                RiskFreeInterestRate = double.Parse(formOptionInputViewModel.InterestRate),
                NbrOfSimulations = Int32.Parse(formOptionInputViewModel.NbrSimulations),
                CallPrice = new Price(),
                PutPrice = new Price(),
                Error = new ErrorType()
            };*/

            Option formOption = AutoMapper.Mapper.Map<Option>(formOptionInputViewModel);

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

            ResultPriceViewModel result = AutoMapper.Mapper.Map<ResultPriceViewModel>(formOption);
            /*ResultPriceViewModel result = new ResultPriceViewModel()
            {
                Bs_CallPrice = formOption.CallPrice.BS.ToString(),
                Bs_PutPrice = formOption.PutPrice.BS.ToString(),
                Mc_CallPrice = formOption.CallPrice.MC.ToString(),
                Mc_PutPrice = formOption.PutPrice.MC.ToString(),
                Error_CallPrice = formOption.Error.Call.ToString(),
                Error_PutPrice = formOption.Error.Put.ToString()
            };*/

            return PartialView("ResultPrice", result); //View("Index", formOption);
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