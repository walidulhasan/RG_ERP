using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_StoreLocationTypes_Setup
    {
        public MM_StoreLocationTypes_Setup()
        {
            MmStoreLocationsSetup = new HashSet<MM_StoreLocations_Setup>();
        }
        [Key]
        public int LocTypeId { get; set; }
        public string LocationtypeName { get; set; }
        public string LocationTypeDesc { get; set; }

        public virtual ICollection<MM_StoreLocations_Setup> MmStoreLocationsSetup { get; set; }
    }
}
