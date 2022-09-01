using System;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class ApprovalModules : DefaultTableProperties
    {
        [Key]
        public int ApprovalModuleID { get; set; }
        public string ApprovalModuleName { get; set; }
        public string ApprovalURL { get; set; }
        public string Description { get; set; }
        public bool IsMasterConfigNeeded { get; set; }
        
    }
}
