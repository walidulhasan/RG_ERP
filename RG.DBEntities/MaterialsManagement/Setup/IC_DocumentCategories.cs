using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_DocumentCategories
    {
        [Key]
        public byte ID { get; set; }
        public string Name { get; set; }
        public int? DocumentID { get; set; }
        public bool? IsAccountsApprovalRequired { get; set; }
    }
}
