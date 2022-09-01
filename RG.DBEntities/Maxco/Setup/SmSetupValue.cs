using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SmSetupValue
    {
        public int Id { get; set; }
        public int SetupTypeId { get; set; }
        public string SetupTypeDescription { get; set; }
    }
}
