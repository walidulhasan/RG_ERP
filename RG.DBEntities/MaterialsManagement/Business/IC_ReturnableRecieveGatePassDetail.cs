using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_ReturnableRecieveGatePassDetail
    {
        [Key]
        public long ID { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public double? GrossWeight { get; set; }
        public long? ReturnableGatePassItemID { get; set; }
        public decimal RecieveQuantity { get; set; }
        public decimal WastageQuantity { get; set; }
        public DateTime? RecieveDate { get; set; }
    }
}
