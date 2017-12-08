using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ELL.ViewModels.Payments
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