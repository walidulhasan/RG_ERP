using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.UserAuthentication
{
    public class UserDashboardAccess:DefaultTableProperties
    {
        [Key]
        public int UserDashboardAccessID { get; set; }
        public int UserID { get; set; }
        public int AccessTypeID { get; set; }
    }
}
