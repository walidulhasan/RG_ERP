using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class ApprovalNotification:DefaultTableProperties
    {
        [Key]
        public int NotificationID { get; set; }
        public string ModuleName { get; set; }
        public int ApprovalMasterID { get; set; }
        public int ApprovalDetailID { get; set; }
        public int? ApproverEmployeeID { get; set; }
        public int? ApplicationID { get; set; }
        public bool IsChecked { get; set; }
        public string Remarks { get; set; }
        public int? CheckedStatus { get; set; }
        public DateTime? CheckedDate { get; set; }
        public bool? IsBackForward { get; set; }
        public DateTime CreatedDateOnly { get; set; }
        
    }
}
