using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.DBViews
{
    public class Vw_BasicCOA
    {
        public int? AccID { get; set; }
        public string AccName { get; set; }
        public int? AccLevel { get; set; }
        public int? Identification_ID { get; set; }
        public string ACC_Identification { get; set; }
        public int? NarrowGroup_ID { get; set; }
        public string Acc_NarrowGroup { get; set; }
        public int? BroadGroup_ID { get; set; }
        public string Acc_BroadGroup { get; set; }
        public int? SubCategory_ID { get; set; }
        public string Acc_SubCategory { get; set; }
        public int? Category_ID { get; set; }
        public string Acc_Category { get; set; }
        public int? CompanyId { get; set; }
        public string Acc_Company { get; set; }
        public string CompanyShort { get; set; }
    }
}
