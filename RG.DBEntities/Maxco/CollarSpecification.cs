using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class CollarSpecification
    {
        public CollarSpecification()
        {
            CollarSizeSpecification = new HashSet<CollarSizeSpecification>();
        }

        public int Id { get; set; }
        public long FabricId { get; set; }
        public bool IsPointed { get; set; }
        public bool IsFolded { get; set; }
        public string Comments { get; set; }
        public byte FabricAndColorId { get; set; }
        public int SelectedFabricTrimId { get; set; }

        public virtual FabricSpecification Fabric { get; set; }
        public virtual FabricTrimFabricAndColorTypeSetup FabricAndColor { get; set; }
        public virtual ICollection<CollarSizeSpecification> CollarSizeSpecification { get; set; }
    }
}
