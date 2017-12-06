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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// The url of the picture
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// The date of birth of the student
        /// </summary>
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
        public int ReferenceNumber { get; set; }

        /// <summary>
        /// The parent id (foreing key to parent)
        /// </summary>
        public int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }
    }
}