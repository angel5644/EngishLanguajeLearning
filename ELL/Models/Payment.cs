using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ELL.Models
{
    [Table("Payment")]
    public class Payment : BaseEntity
    {
        /// <summary>
        /// The payment id
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The student id (foreing key to student)
        /// </summary>
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Required]
        public DateTime Date { get; set; }

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