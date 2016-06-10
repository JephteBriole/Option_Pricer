using PricerWebClient.Models;
using PricerWebClient.PricerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricerWebClient.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<OptionInputViewModel, Option>()
                .ForMember(dest => dest.UnderlyingPrice, opts => opts.MapFrom(src => src.Spot))
                .ForMember(dest => dest.Strike, opts => opts.MapFrom(src => src.Strike))
                .ForMember(dest => dest.Volatility, opts => opts.MapFrom(src => src.Volatility))
                .ForMember(dest => dest.Maturity, opts => opts.MapFrom(src => src.Maturity))
                .ForMember(dest => dest.RiskFreeInterestRate, opts => opts.MapFrom(src => src.InterestRate))
                .ForMember(dest => dest.NbrOfSimulations, opts => opts.MapFrom(src => src.NbrSimulations))
                .ReverseMap()
                );

            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Option, ResultPriceViewModel>()
                .ForMember(dest => dest.Mc_CallPrice, opts => opts.MapFrom(src => src.CallPrice.MC))
                .ForMember(dest => dest.Mc_PutPrice, opts => opts.MapFrom(src => src.PutPrice.MC))
                .ForMember(dest => dest.Bs_CallPrice, opts => opts.MapFrom(src => src.CallPrice.BS))
                .ForMember(dest => dest.Bs_PutPrice, opts => opts.MapFrom(src => src.PutPrice.BS))
                .ForMember(dest => dest.Error_CallPrice, opts => opts.MapFrom(src => src.Error.Call))
                .ForMember(dest => dest.Error_PutPrice, opts => opts.MapFrom(src => src.Error.Put))
                .ReverseMap()
                );
        }
    }
}