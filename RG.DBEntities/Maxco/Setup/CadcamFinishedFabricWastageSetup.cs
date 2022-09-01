using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;
namespace RG.DBEntities.Maxco.Setup
{
    public partial class CadcamFinishedFabricWastageSetup
    {
        public CadcamFinishedFabricWastageSetup()
        {
            CadcamWastagePercentage = new HashSet<CadcamWastagePercentage>();
        }

        public int Id { get; set; }
        public int FabricQualityId { get; set; }
        public string FabricComposition { get; set; }
        public int DyeingId { get; set; }
        public int Gsm { get; set; }
        public int MachineTypeId { get; set; }
        public string Color { get; set; }
        public int FinishedWidth { get; set; }

        public virtual FabricQuality_Setup FabricQuality { get; set; }
        public virtual ICollection<CadcamWastagePercentage> CadcamWastagePercentage { get; set; }
    }
}
