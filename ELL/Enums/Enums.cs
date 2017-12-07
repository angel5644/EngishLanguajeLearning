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
            Male = 0,
            Female = 1,
            [Display(Name = "Not Specified")]
            NotSpecified = 2
        }
    }
}