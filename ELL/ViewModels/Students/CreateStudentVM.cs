using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ELL.Enums.Enums;

namespace ELL.ViewModels.Students
{
    [NotMapped]
    public class CreateStudentVM
    {
        /// <summary>
        /// The student id
        /// </summary>
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Monthly payment of the student
        /// </summary>
        [Required]
        public decimal MonthlyPayment { get; set; }

        /// <summary>
        /// Student email
        /// </summary>
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
        public string Phone { get; set; }

        /// <summary>
        /// A unique reference number that will be asigned to every student
        /// </summary>
        [Required]
        [Display(Name = "Reference Number")]
        public int ReferenceNumber { get; set; }

        /// <summary>
        /// The contact id (foreing key to contact)
        /// </summary>
        [Required]
        [Display(Name = "Emergency Contact")]
        public int ParentId { get; set; }

        public SelectList EmergencyContacts { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}