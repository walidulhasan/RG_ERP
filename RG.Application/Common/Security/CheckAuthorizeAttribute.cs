﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Common.Security
{
    /// <summary>
    /// Specifies the class this attribute is applied to requires authorization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CheckAuthorizeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckAuthorizeAttribute"/> class. 
        /// </summary>
        public CheckAuthorizeAttribute() { }

        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// Gets or sets the policy name that determines access to the resource.
        /// </summary>
        public string Policy { get; set; }
    }
}
