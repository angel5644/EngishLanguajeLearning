using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ELL.Enums.Enums;

namespace ELL.Models.Log
{
    [Table("ELLLog")]
    public class ELLLog
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The date
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The ELL exception type. See <see cref="ELL.Enums.Enums.ELLLogType"/>
        /// </summary>
        [Required]
        public ELLLogType Type { get; set; }

        /// <summary>
        /// The message of the log
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// The stacktrace of the exception if any
        /// </summary>
        public string Stacktrace { get; set; }
        
        /// <summary>
        /// The object that caused the exception if any
        /// </summary>
        public string ObjectString { get; set; }
    }

}
