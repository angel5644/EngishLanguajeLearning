using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ELL.ViewModels.Payment
{
    public class CreatePaymentVM
    {
        /// <summary>
        /// The payment id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The student id selected
        /// </summary>
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        //[ForeignKey("StudentId")]
        //public virtual Student Student { get; set; }
        public SelectList Students { get; set; }
        

        /// <summary>
        /// The amount of the payment
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// The description of the payment. For example: sign up, monthly fee, etc.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}