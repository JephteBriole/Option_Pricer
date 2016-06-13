using AutoMapper;
using PricerWebClient.Mapping;
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
            Mapper.Initialize(x =>
            {
                x.AddProfile<OptionMappingProfile>();
            });
        }
    }
}