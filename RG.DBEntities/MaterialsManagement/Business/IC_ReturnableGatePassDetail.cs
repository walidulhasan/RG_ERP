using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_ReturnableGatePassDetail : DefaultTableProperties
    {
        [Key]
        public long ID { get; set; }
        public int ReturnableItemCategoryID { get; set; }
        public int RequisitionID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal? GrossWeight { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("IC_ReturnableGatePassMaster")]
        public long? ReturnableGatePassID { get; set; }
        public decimal? RecieveQuantity { get; set; }
        public decimal? WastageQuantity { get; set; }
        public virtual IC_ReturnableGatePassMaster IC_ReturnableGatePassMaster { get; set; }
    }
}
