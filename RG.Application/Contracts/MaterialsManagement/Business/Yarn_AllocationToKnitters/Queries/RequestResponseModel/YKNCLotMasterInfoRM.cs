using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YKNCLotMasterInfoRM
    {
        public int? MRPItemCode { get; set; }
        public long? AttributeInstanceID { get; set; }
        public long? YarnAttributeInstanceID { get; set; }
        public long? SupplierID { get; set; }
        public int? BrandID { get; set; }
        public int? PackagingID { get; set; }
        public int? ConesPerProcurementUnit { get; set; }
        public int? UnitID { get; set; }
        public string UnitName { get; set; }
        public long? StoreLocationID { get; set; }
        public string LocationName { get; set; }
        public decimal? Rate { get; set; }
        public long? RateUnitID { get; set; }
        public decimal? MovingAverage { get; set; }
        public decimal? TransactionQty { get; set; }
        public int? ProgramTypeID { get; set; }
        public string LotNo { get; set; }
        public int? Status { get; set; }
        public decimal? RateWRTBaseUnit { get; set; }
        public long? YKNCID { get; set; }
        public decimal AllocatedQty { get; set; }
        public decimal IssuedQty { get; set; } = 0;

        public long CompanyID { get; set; }
        public int BusinessID { get; set; }
        public decimal AllocatedBalance { get { return AllocatedQty - IssuedQty; } }


    }
}
