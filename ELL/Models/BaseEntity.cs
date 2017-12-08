﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELL.Models
{
    /// <summary>
    /// Defines the base properties of the entity. Like DateCreated, UserCreated, DateUpdated and UserUpdated.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// The date when the entity was created
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// User who created the entity
        /// </summary>
        public string UserCreated { get; set; }
        
        /// <summary>
        /// The date of the last update
        /// </summary>
        public DateTime? DateUpdated { get; set; }

        /// <summary>
        /// User who updated the entity 
        /// </summary>
        public string UserUpdated { get; set; }
    }
}