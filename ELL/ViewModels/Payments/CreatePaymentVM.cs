using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using static ELL.Enums.Enums;

namespace ELL.ViewModels.Payments
{
    [NotMapped]
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

        public SelectList Students { get; set; }

        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// The amount of the payment
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// The payment type. See <see cref="ELL.Enums.Enums.PaymentType"/>
        /// </summary>
        [Display(Name = "Payment Type")]
        [Required]
        public PaymentType Type { get; set; }

        /// <summary>
        /// The description of the payment. For example: sign up, monthly fee, etc.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}