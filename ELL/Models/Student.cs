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
    public class Student : BaseEntity
    {
        /// <summary>
        /// The student id
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(255)]
        [Index]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(255)]
        [Index]
        public string LastName { get; set; }

        /// <summary>
        /// Monthly payment of the student
        /// </summary>
        [Required]
        public decimal MonthlyPayment { get; set; }

        /// <summary>
        /// Student email
        /// </summary>
        [Index]
        [StringLength(255)]
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
        /// The phone number of the student or the emergency contact
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        /// <summary>
        /// A unique reference number that will be asigned to every student
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        [Display(Name = "Reference Number")]
        public int ReferenceNumber { get; set; }

        /// <summary>
        /// The contact id (foreing key to contact)
        /// </summary>
        [Required]
        [Display(Name = "Emergency Contact")]
        public int EmergencyContactId { get; set; }

        [ForeignKey("EmergencyContactId")]
        public virtual EmergencyContact EmergencyContact { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}