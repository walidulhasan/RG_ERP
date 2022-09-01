using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries.RequestResponseModel
{
   public class UserWiseDepartmentRM
    {
        public int ID { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool? IsRemove { get; set; }
        public int UserID { get; set; }
        public int? AuthUserId { get; set; } = 0;
        public int UserDepartmentSetupID { get; set; }
    }
}
