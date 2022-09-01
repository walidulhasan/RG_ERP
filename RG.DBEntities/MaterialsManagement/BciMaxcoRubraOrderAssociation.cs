using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciMaxcoRubraOrderAssociation
    {
        public long Id { get; set; }
        public string Maxco { get; set; }
        public string Rubra { get; set; }
    }
}
