using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialIssueMaster
    {[Key]
        public int Mimid { get; set; }
        public DateTime IssueDate { get; set; }
        public string GatePassNo { get; set; }
        public string ReceivingPerson { get; set; }
        public string Remarks { get; set; }
    }
}
