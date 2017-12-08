using AutoMapper;
using ELL.Models;
using ELL.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELL.Core
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                // Add profiles
                cfg.AddProfile(new PaymentProfile());
                //cfg.AddProfile(new PostProfile());
            });
        }

        

        // ... etc
    }
}