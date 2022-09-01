using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.DBViews
{
    public class VW_ChartOfAccounts
    {
        public int ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string AccountCode { get; set; }
        public int LevelID { get; set; }
        public int? ParentID { get; set; }

        public string ParentName { get; set; }
        
        public int ParentLevel { get; set; }
    }
}
