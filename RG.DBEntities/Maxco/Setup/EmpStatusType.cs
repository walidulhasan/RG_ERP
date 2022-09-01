using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class EmpStatusType
    {
        public int ID { get; set; }
        public string EmpStatusTypeName { get; set; }
        public string EmpStatusTypeNameUc { get; set; }
        public string Description { get; set; }
        public bool? IsRunningEmployee { get; set; }
        public int CompanyID { get; set; }
        
    }
}
