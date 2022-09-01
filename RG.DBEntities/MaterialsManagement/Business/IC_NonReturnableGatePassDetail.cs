using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_NonReturnableGatePassDetail : DefaultTableProperties
    {
        [Key]
        public long ID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal GrossWeight { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("IC_NonReturnableGatePassMaster")]
        public long NonReturnableGatePassID { get; set; }
        public virtual IC_NonReturnableGatePassMaster IC_NonReturnableGatePassMaster { get; set; }
    }
}
