using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.COAGroups.Querirs.RequestResponseModel
{
    public class COAGroupingRM
    {
        public int GroupID { get; set; }
        public int GroupCategoryID { get; set; }
        public string GroupCode { get; set; }
        public int GroupSerial { get; set; }
        public string GroupName { get; set; }
        public string GroupCategoryName { get; set; }
    }
}
