using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SetupUrlSetup
    {
        public SetupUrlSetup()
        {
            SetupUrlAssigned = new HashSet<SetupUrlAssigned>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public virtual ICollection<SetupUrlAssigned> SetupUrlAssigned { get; set; }
    }
}
