using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ELL.Enums
{
    public static class Enums
    {
        public enum Gender
        {
            [Display(Name = "Not Specified")]
            NotSpecified = 0,
            Female = 1,
            Male = 2,
        }

        public enum ELLLogType
        {
            Debug,
            Information,
            Warning,
            Error
        }

        public enum PaymentType
        {
            [Display(Name = "Monthly Payment")]
            MonthlyPayment = 0,
            Registration = 1,
            Other = 2
        }
    }
}