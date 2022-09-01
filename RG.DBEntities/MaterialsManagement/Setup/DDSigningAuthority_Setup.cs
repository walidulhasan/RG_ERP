using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public partial class DDSigningAuthority_Setup
    {
        public bool? IsDefault { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
    }
}
