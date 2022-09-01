using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SetupUrlAssigned
    {
        public int Id { get; set; }
        public int? SetupUrlId { get; set; }
        public int? UserId { get; set; }
        public DateTime? AssignDate { get; set; }
        public int? AssignedBy { get; set; }

        public virtual SetupUrlSetup SetupUrl { get; set; }
    }
}
