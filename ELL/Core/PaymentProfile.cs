using AutoMapper;
using ELL.Models;
using ELL.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELL.Core
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, CreatePaymentVM>().ReverseMap();
        }
    }
}