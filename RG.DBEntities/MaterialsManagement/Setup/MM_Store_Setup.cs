using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class MM_Store_Setup
    {
        public MM_Store_Setup()
        {
            //MmStoreCategoryRelation = new HashSet<MmStoreCategoryRelation>();
            //MmStoreLocationsSetup = new HashSet<MmStoreLocationsSetup>();
        }

        [Key]
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public string StoreShortName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Scode { get; set; }
        public int? ParentStoreID { get; set; }
        public int IsMainStore { get; set; }

       // public virtual ICollection<MmStoreCategoryRelation> MmStoreCategoryRelation { get; set; }
       // public virtual ICollection<MmStoreLocationsSetup> MmStoreLocationsSetup { get; set; }
    }
}
