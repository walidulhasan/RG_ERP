using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_LocalSalesGatePassMaster : DefaultTableProperties
    {
        [Key]
        public long GatePassID { get; set; }
        public long CustomerID { get; set; }
        public long DepartmentID { get; set; }
        public int? ProcessID { get; set; }
        public long IssuedBy { get; set; }
        public bool? IsSelfVehicle { get; set; }
        public int? PaymentMode { get; set; }
        public virtual IC_GatepassMaster IC_GatepassMaster { get; set; }
        public List<IC_LocalSalesGatePassDetail> IC_LocalSalesGatePassDetail { get; set; }
    }
}
