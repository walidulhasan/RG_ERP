using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class MM_StoreLocations_Setup
    {
        [Key]
        public int StoreLocationID { get; set; }
        public int StoreID { get; set; }
        public string SlName { get; set; }
        public string Sldescription { get; set; }
        public int LocTypeID { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string UnitID { get; set; }
        public long? SupplierID { get; set; }

        public virtual MM_StoreLocationTypes_Setup LocType { get; set; }
        public virtual MM_Store_Setup Store { get; set; }
    }
}
