using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YKNCMasterInfoRM
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public long YKNCID { get; set; }
        public int GreigeMRP { get; set; }
        public long GreigeAttributeInstanceID { get; set; }
        public int ContractStatus { get; set; }
        public long KnitterID { get; set; }
        public string KnitterName { get; set; }
        public string ContractName { get; set; }
        public DateTime ContractDate { get; set; }
        public string ContractDateMsg { get { return ContractDate.ToString("dd-MMM-yyyy"); } }
        public int ProgramTypeID { get; set; }
        public string ProgramType { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int IsClosed { get; set; }
        public string NoOfDayes { get; set; }
        public string PaymentTerm { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public double TotalQty { get; set; }       
        public int ContractTypeID { get; set; }
        public double AllocatedQuantity { get; set; }
        
    }
}
