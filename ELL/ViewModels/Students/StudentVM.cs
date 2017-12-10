using ELL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ELL.Enums.Enums;

namespace ELL.ViewModels.Students
{
    public class StudentVM
    {
        /// <summary>
        /// The student id
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Monthly payment of the student
        /// </summary>
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
        public string Phone { get; set; }

        /// <summary>
        /// A unique reference number that will be asigned to every student
        /// </summary>
        [Display(Name = "Reference Number")]
        public int ReferenceNumber { get; set; }

        /// <summary>
        /// The contact id (foreing key to contact)
        /// </summary>
        [Display(Name = "Emergency Contact")]
        public int EmergencyContactId { get; set; }

        //public EmergencyContact EmergencyContact { get; set; }

        /// <summary>
        /// Emergency Contact of the student full name
        /// </summary>
        [Display(Name = "Contact")]
        public string ContactName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}