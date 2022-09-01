using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_ExportSalesGatePassMaster : DefaultTableProperties
    {
        public IC_ExportSalesGatePassMaster()
        {
            IC_ExportSalesGatePassDetail = new List<IC_ExportSalesGatePassDetail>();
        }
        [Key]
        public long? GatePassId { get; set; }
        public string CustomerId { get; set; }
        public long? IssuedBy { get; set; }
        public string Purpose { get; set; }
        public string VehicleRef { get; set; }
        public string Description { get; set; }
        public string DriverName { get; set; }
        public string MobileNo { get; set; }
        public string TransportServiceName { get; set; }
        public long? DepartmentID { get; set; }
        public virtual IC_GatepassMaster IC_GatepassMaster { get; set; }
        public virtual List<IC_ExportSalesGatePassDetail> IC_ExportSalesGatePassDetail { get; set; }
    }
}
