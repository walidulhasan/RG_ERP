using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class Designation
    {
        public int ID { get; set; }
        public string DesignationName { get; set; }
        public string DesignationNameUc { get; set; }
        public string Code { get; set; }
        public int CompanyID { get; set; }
        
    }
}
