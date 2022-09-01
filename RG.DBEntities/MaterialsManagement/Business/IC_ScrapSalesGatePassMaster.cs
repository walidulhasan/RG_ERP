using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_ScrapSalesGatePassMaster : DefaultTableProperties
    {
        [Key]
        public long GatePassID { get; set; }
        public long ScrapCustomerID { get; set; }
        public long IssuedBy { get; set; }
        public string WeightSlipNo { get; set; }
        public int? DepartmentId { get; set; }
        public string VehicleDriverMobileNo { get; set; }
        public string Description { get; set; }
        public bool? IsSelfVehicle { get; set; }
        public int? PaymentMode { get; set; }
        public virtual IC_GatepassMaster IC_GatepassMaster { get; set; }
        public List<IC_ScrapSalesGatePassDetail> IC_ScrapSalesGatePassDetail { get; set; }
    }
}
