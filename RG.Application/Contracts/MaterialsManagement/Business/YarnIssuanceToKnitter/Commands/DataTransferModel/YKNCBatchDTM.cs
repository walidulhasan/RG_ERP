using FluentValidation;
using RG.Application.Common.Mappings;
using RG.Application.Contracts.MaterialsManagement.Business.AllocatedYarnIssueFromRack.DataTransferModel;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel
{
    public class YKNCBatchDTM:IMapFrom<Yarn_StockTransactions>
    {
        public YKNCBatchDTM()
        {
            AllocatedYarnIssueFromRack = new List<AllocatedYarnIssueFromRackDTM>();
        }
        public int? MRPItemCode{get;set;}
       public long? AttributeInstanceID{get;set;}
       public long? YarnAttributeInstanceID {get;set;}
       public long? SupplierID {get;set;}
       public int? BrandID{get;set;}
       public int? PackagingID{get;set;}
       public int? ConesPerProcurementUnit{get;set;}
       public int? UnitID{get;set;}
       public string UnitName { get;set;}
       public long? LocationID{get;set;}
       public string Loaction{get;set;}
       public decimal? Rate { get;set;}
       public long? RateUnitID { get;set;}
       public decimal? MovingAverage {get;set;}
       public decimal? TransactionQty {get;set;}
       public int? ProgramTypeID{get;set;}
       public string LotNo{get;set;}
       public int? Status{get;set;}
       public decimal? RateWRTBaseUnit {get;set;}
       public string SupplierName{get;set;}
       public long? YarnKnittingContractID{get;set;}
       
       public decimal AllocatedQty {get;set;}
       
       public long CompanyID {get;set;}
       public int BusinessID{get;set;}
       
       public decimal IssuedQty {get;set;}       
       public int? IssuingUnitID{get;set;}
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public List<AllocatedYarnIssueFromRackDTM> AllocatedYarnIssueFromRack { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<YKNCBatchDTM, Yarn_StockTransactions>();
        }

    }
   
}
