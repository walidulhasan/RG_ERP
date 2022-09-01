using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.UserAuthentication
{
    public class DashboardAccessType : DefaultTableProperties
    {
        [Key]
        public int AccessTypeID { get; set; }
        public int ProjectID { get; set; }
        public string AccessTypeName { get; set; }
    }
}