using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfWebService
{
    public class Service : IService
    {
        #region ***** Computation ***** 

        #region Black & Scholes 
        /// <summary>
        /// Cumulative normal distribution function
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private double CumulativeNormalDistributionFun(double d)
        {
            double L = 0.0;
            double K = 0.0;
            double dCND = 0.0;
            const double a1 = 0.31938153;
            const double a2 = -0.356563782;
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;
            L = Math.Abs(d);
            K = 1.0 / (1.0 + 0.2316419 * L);

            dCND = 1.0 - 1.0 / Math.Sqrt(2.0 * Convert.ToDouble(Math.PI)) * Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) + a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));

            if (d < 0)
            {
                return 1.0 - dCND;
            }
            else
            {
                return dCND;
            }
        }

        public Option BlackScholesModel(double d1, double d2, Option option)
        {
            Console.WriteLine("Starting Black-Scholes Computation ...");
            option.CallPrice.BS = option.UnderlyingPrice * CumulativeNormalDistributionFun(d1) - option.Strike * Math.Exp(-option.RiskFreeInterestRate * option.Maturity) * CumulativeNormalDistributionFun(d2);
            option.PutPrice.BS = option.Strike * Math.Exp(-option.RiskFreeInterestRate * option.Maturity) * CumulativeNormalDistributionFun(-d2) - option.UnderlyingPrice * CumulativeNormalDistributionFun(-d1);
            Console.WriteLine("End Black-Scholes !");

            return option;
        }
        #endregion

        #region Monte Carlo 
        private double GetRandom_BoxMuller(Random rnd)
        {
            double result = 0.0;
            double x = 0.0;
            double y = 0.0;

            do
            {
                x = 2.0 * rnd.NextDouble() - 1.0;
                y = 2.0 * rnd.NextDouble() - 1.0;

                result = x * x + y * y;
            }
            while (result >= 1.0 || result == 0);

            return x * Math.Sqrt(-2.0 * Math.Log(result) / result);
        }
        public Option MonteCarloModel(Option option)
        {
            Console.WriteLine("Starting Monte Carlo Computation ...");

            Random rnd = new Random();

            double sigmaT = option.Volatility * option.Volatility * option.Maturity;
            double sqrtSigmaT = Math.Sqrt(sigmaT);
            double spotDrift = option.UnderlyingPrice * Math.Exp(option.RiskFreeInterestRate * option.Maturity - sigmaT / 2.0);
            double discountFactor = Math.Exp(-option.RiskFreeInterestRate * option.Maturity);
            double callPayoff_Sum = 0.0;
            double putPayoff_Sum = 0.0;
            double stockPrice = 0.0;

            Parallel.For(0, option.NbrOfSimulations,
                index =>
                {
                    double rndNumber = this.GetRandom_BoxMuller(rnd);
                    stockPrice = spotDrift * Math.Exp(rndNumber * sqrtSigmaT);
                    callPayoff_Sum += Math.Max(stockPrice - option.Strike, 0.0);
                     
                    putPayoff_Sum += Math.Max(option.Strike - stockPrice, 0.0);
                });

            /*for (int i = 0; i < option.NbrOfSimulations; i++)
            {
                double rndNumber = this.GetRandom_BoxMuller(rnd);
                stockPrice = spotDrift * Math.Exp(rndNumber * sqrtSigmaT);
                callPayoff_Sum += Math.Max(stockPrice - option.Strike, 0.0);

                //rndNumber = this.GetRandom_BoxMuller();
                //stockPrice = spotDrift * Math.Exp(rndNumber * sqrtSigmaT);
                putPayoff_Sum += Math.Max(option.Strike - stockPrice, 0.0);
            }*/

            option.CallPrice.MC = callPayoff_Sum * discountFactor / option.NbrOfSimulations;
            option.PutPrice.MC = putPayoff_Sum * discountFactor / option.NbrOfSimulations;

            return option;
        }
        #endregion

        #endregion
    }
}
