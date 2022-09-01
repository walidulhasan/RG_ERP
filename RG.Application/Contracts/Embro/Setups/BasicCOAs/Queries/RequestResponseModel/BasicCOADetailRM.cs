using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries.RequestResponseModel
{
    public class BasicCOADetailRM
    {
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategory { get; set; }
        public int BroadGroupID { get; set; }
        public string BroadGroup { get; set; }
        public int NarrowGroupID { get; set; }
        public string NarrowGroup { get; set; }
        public int IdentificationID { get; set; }
        public string Identification { get; set; }
        public int ItemID { get; set; }
        public string Item { get; set; }
        public bool IsAssignedIdentification { get; set; }
        public bool IsIgnoredItem { get; set; }
        public int GroupIdentificationID { get; set; }
        public int IdentificationAssignedCategoryID { get; set; }
        public string IdentificationAssignedGroupID { get; set; }
        public string IdentificationAssignedGroup { get; set; }
    }
}
