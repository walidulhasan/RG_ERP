using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_ReturnableItemCategory : DefaultTableProperties
    {
        [Key]
        public int ReturnableItemCategoryID { get; set; }
        public string ReturnableItemCategoryName { get; set; }
    }
}
