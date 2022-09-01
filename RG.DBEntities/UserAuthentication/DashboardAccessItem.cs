using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.UserAuthentication
{
    public class DashboardAccessItem:DefaultTableProperties
    {
        [Key]
        public int AccessItemID { get; set; }
        public int ProjectID { get; set; }
        public string AccessItemName { get; set; }
    }
}
