using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedIssuanceMaster
    {
        [Key]
        public long IssuanceId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string IssuancePerson { get; set; }
        public string IssuanceNo { get; set; }
        public int UserId { get; set; }
        public int? IsReceived { get; set; }
        public long? AssignmentType { get; set; }
    }
}
