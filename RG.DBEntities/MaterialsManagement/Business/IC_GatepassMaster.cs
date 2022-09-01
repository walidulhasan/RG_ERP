using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_GatepassMaster : DefaultTableProperties
    {        
        public long ID { get; set; }
        public string Serial { get; set; }
        public DateTime? DateTimeStamp { get; set; }
        public string VehicleNo { get; set; }
        public long? ApprovedBy { get; set; }
        public int? ApprovedID { get; set; }
        public byte? CategoryID { get; set; }
        public bool? isApproved { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public bool? isDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool? isMarkedOut { get; set; }
        public long? MarkedOutBy { get; set; }
        public int? MarkedOutID { get; set; }
        public DateTime? MarkedOutOn { get; set; }
        public long? CompanyID { get; set; }
        public long? GID { get; set; }
        public long? SEQ { get; set; }
        public bool? IsApprovedByAccounts { get; set; }
        public long? AccountsApprovedBy { get; set; }
        public DateTime? AccountsApprovalDate { get; set; }
        public virtual IC_LocalSalesGatePassMaster IC_LocalSalesGatePassMaster { get; set; }
        public virtual IC_ExportSalesGatePassMaster IC_ExportSalesGatePassMaster { get; set; }
        public virtual IC_ScrapSalesGatePassMaster IC_ScrapSalesGatePassMaster { get; set; }
        public virtual IC_NonReturnableGatePassMaster IC_NonReturnableGatePassMaster { get; set; }
        public virtual IC_ReturnableGatePassMaster IC_ReturnableGatePassMaster { get; set; }
        public virtual IC_SampleGatePassMaster IC_SampleGatePassMaster { get; set; }

    }
}
