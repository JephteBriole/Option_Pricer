using Option_Pricer_Mvvm.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Input;
using Option_Pricer_Mvvm.PricerService;

namespace Option_Pricer_Mvvm.ViewModel
{
    class OptionViewModel : ViewModelBase
    {
        private Option _option;
        private ICommand _computeCommand;
        private ICommand _resetCommand;
        private ServiceClient _client;
        List<double> listX = new List<double>();
        List<double> listReturn = new List<double>();

        #region ----- Constructor ----- 
        public OptionViewModel()
        {
            this._client = new ServiceClient();
            this._option = new Option
            {
                Maturity = 1,
                RiskFreeInterestRate = 0.05,
                Strike = 148,
                UnderlyingPrice = 150,
                Volatility = 0.1,
                NbrOfSimulations = 100000
            };

            this._option.CallPrice = new Price();
            this._option.PutPrice = new Price();
            this._option.Error = new ErrorType();

            this.CalculatePrice();
        }
        #endregion

        #region ----- Properties ------ 
        private bool PropertiesChanged { get; set; }
        public double UnderlyingPrice
        {
            get
            {
                return this._option.UnderlyingPrice;
            }
            set
            {
                this._option.UnderlyingPrice = value;
                this.PropertiesChanged = this.PropertiesChanged == false;
                this.OnPropertyChanged("UnderlyingPrice");
            }
        }

        public double Strike
        {
            get
            {
                return this._option.Strike;
            }
            set
            {
                this._option.Strike = value;
                this.PropertiesChanged = this.PropertiesChanged == false;
                this.OnPropertyChanged("Strike");
            }
        }

        public double RiskFreeInterestRate
        {
            get
            {
                return this._option.RiskFreeInterestRate;
            }
            set
            {
                this._option.RiskFreeInterestRate = value;
                this.PropertiesChanged = this.PropertiesChanged == false;
                this.OnPropertyChanged("RiskFreeInterestRate");
            }
        }

        public double Maturity
        {
            get
            {
                return this._option.Maturity;
            }
            set
            {
                this._option.Maturity = value;
                this.PropertiesChanged = this.PropertiesChanged == false;
                this.OnPropertyChanged("Maturity");
            }
        }

        public double Volatility
        {
            get
            {
                return this._option.Volatility;
            }
            set
            {
                this._option.Volatility = value;
                this.PropertiesChanged = this.PropertiesChanged == false;
                this.OnPropertyChanged("Volatility");
            }
        }

        public int NbrOfSimulations
        {
            get
            {
                return this._option.NbrOfSimulations;
            }
            set
            {
                this._option.NbrOfSimulations = value;
                this.PropertiesChanged = this.PropertiesChanged == false;
                this.OnPropertyChanged("NbrOfSimulations");
            }
        }

        public Price CallPrice
        {
            get { return this._option.CallPrice; }
            set
            {
                value.BS = value.BS != null ? (double?)Math.Round((double)value.BS, 4) : null;
                value.MC = value.MC != null ? (double?)Math.Round((double)value.MC, 4) : null;
                
                this._option.CallPrice = value;
                OnPropertyChanged("CallPrice");
            }
        }

        public Price PutPrice
        {
            get { return this._option.PutPrice; }
            set
            {
                value.BS = value.BS != null ? (double?)Math.Round((double)value.BS, 4) : null;
                value.MC = value.MC != null ? (double?)Math.Round((double)value.MC, 4) : null;
                
                this._option.PutPrice = value;
                OnPropertyChanged("PutPrice");
            }
        }

        public ErrorType Error
        {
            get
            {
                return this._option.Error;
            }
            set
            {
                value.Call = (this.CallPrice.MC != null && this.CallPrice.BS != null) ? (double?)Math.Round((double)(this.CallPrice.BS != 0 ? (this.CallPrice.MC - this.CallPrice.BS) / this.CallPrice.BS : 0), 4) : null;
                value.Put = (this.PutPrice.MC != null && this.PutPrice.BS != null) ? (double?)Math.Round((double)(this.PutPrice.BS != 0 ? (this.PutPrice.MC - this.PutPrice.BS) / this.PutPrice.BS : 0), 4) : null;

                this._option.Error = value;
                OnPropertyChanged("Error");
            }
        }

        public ICommand ComputeCommand
        {
            get
            {
                if (this._computeCommand == null)
                {
                    this._computeCommand = new RelayCommand(() => CalculatePrice(),
                                                           () => CanCompute());
                }
                    
                return _computeCommand;
            }
        }

        public ICommand ResetCommand
        {
            get
            {
                if (this._resetCommand == null)
                    this._resetCommand = new RelayCommand(() => ResetAll());
                return _resetCommand;
            }
        }
        #endregion

        #region ***** Computation ***** 
        /// <summary>
        ///  Get Option price by applying BlackSholesOptionPricingModel
        /// </summary>
        /// <returns></returns>
        public async void CalculatePrice()
        {
            double d1 = 0.0;
            double d2 = 0.0;

            d1 = (Math.Log(UnderlyingPrice / Strike) + (RiskFreeInterestRate + Volatility * Volatility / 2.0) * Maturity) / (Volatility * Math.Sqrt(Maturity));
            d2 = d1 - Volatility * Math.Sqrt(Maturity);

            this._option = await this._client.MonteCarloModelAsync(this._option);
            this._option = await this._client.BlackScholesModelAsync(d1, d2, this._option);
            
            this.CallPrice = this._option.CallPrice;
            this.PutPrice = this._option.PutPrice;
            this.Error = this._option.Error;
        }
        #endregion
        private bool CanCompute()
        {
            return (this._option.UnderlyingPrice > 0 && this._option.Strike > 0) && (this._option.Volatility > 0 && this._option.Maturity > 0);
        }
        private void ResetAll() 
        {
            this.CallPrice = new Price() { BS = null, MC = null };
            this.PutPrice = new Price() { BS = null, MC = null };
            this.Error = new ErrorType() { Call = null, Put = null };

            this.Maturity = 1;
            this.RiskFreeInterestRate = 0.05;
            this.Strike = 148;
            this.UnderlyingPrice = 150;
            this.Volatility = 0.1;
            this.NbrOfSimulations = 100000;
        }
    }
}
