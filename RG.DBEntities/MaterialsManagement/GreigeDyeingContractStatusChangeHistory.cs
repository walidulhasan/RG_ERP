using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeDyeingContractStatusChangeHistory
    {
        public int Dcid { get; set; }
        public int Id { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}
