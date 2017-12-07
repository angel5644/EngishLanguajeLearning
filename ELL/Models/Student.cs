using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static ELL.Enums.Enums;

namespace ELL.Models
{
    [Table("Student")]
    public class Student
    {
        /// <summary>
        /// The student id
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// The url of the picture
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// The date of birth of the student
        /// </summary>
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gender of the student.
        /// <see cref="ELL.Enums.Enums.Gender"/> 
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// A reference number that will be asigned to every student
        /// </summary>
        [Required]
        [Display(Name = "Reference Number")]
        public int ReferenceNumber { get; set; }

        /// <summary>
        /// The parent id (foreing key to parent)
        /// </summary>
        [Required]
        [Display(Name = "Parent")]
        public int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}