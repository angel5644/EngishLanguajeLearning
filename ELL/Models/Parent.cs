using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ELL.Models
{
    [Table("Parent")]
    public class Parent
    {
        /// <summary>
        /// The parent id
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The first name 
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        public string Phone { get; set; }
    }
}