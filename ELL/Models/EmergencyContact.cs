using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ELL.Models
{
    /// <summary>
    /// The emergency contact of the student
    /// </summary>
    [Table("EmergencyContact")]
    public class EmergencyContact : BaseEntity
    {
        /// <summary>
        /// The contact id
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The first name 
        /// </summary>
        [Display(Name = "First Name")]
        [Required]
        [StringLength(500)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(500)]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}