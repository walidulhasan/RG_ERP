using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_NonReturnableGatePassMaster : DefaultTableProperties
    {
      
        public long GatePassID { get; set; }
        public long IssuedBy { get; set; }
        public string IssuedToID { get; set; }
        public long? CustomerID { get; set; }
        public string Purpose { get; set; }
        public int? DepartmentID { get; set; }
        public virtual IC_GatepassMaster IC_GatepassMaster { get; set; }
        public virtual List<IC_NonReturnableGatePassDetail> IC_NonReturnableGatePassDetail { get; set; }
    }
}
