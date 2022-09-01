using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedRollAssignmentMaster
    {
        [Key]
        public long AssignmentId { get; set; }
        public string AssignmentNo { get; set; }
        public DateTime AssignmentDate { get; set; }
        public int? UserId { get; set; }
        public int? AssignmentType { get; set; }
        public int? Status { get; set; }
        public string Comments { get; set; }
    }
}
