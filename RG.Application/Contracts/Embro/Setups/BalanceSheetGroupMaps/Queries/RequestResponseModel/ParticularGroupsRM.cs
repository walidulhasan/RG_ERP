using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries.RequestResponseModel
{
    public class ParticularGroupsRM
    {
        public int? ParticularSerial { get; set; }
        public int? COAGroupID { get; set; }
        public string GroupCode { get; set; }
        public string COAGroupName { get; set; }
    }
}
