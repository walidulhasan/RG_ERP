using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class GeneralConfigurationSetup
    {
        public long ID { get; set; }
        public string Parameter { get; set; }
        public long? AccountID { get; set; }
        public long? BusinessID { get; set; }
    }
}
