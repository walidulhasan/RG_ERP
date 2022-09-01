using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.UserAuthentication
{
    public class DashboardAccessTypeItemMap:DefaultTableProperties
    {
        [Key]
        public int AccessTypeItemMapID { get; set; }
        public int AccessTypeID { get; set; }
        public int AccessItemID { get; set; }
    }
}
