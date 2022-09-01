using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel
{
    public class YarnAttributeInfoRM:IMapFrom<View_AttributeInstanceYarnInfo>
    {
        public YarnAttributeInfoRM()
        {
            YKNCLotMasterDetailInfo = new List<YKNCLotMasterDetailInfoRM>();
        }
        public string YarnType { get; set; }
        public long AttributeInstanceID { get; set; }
        public int MRPItemCode { get; set; }
        public int YarnCompositionID { get; set; }
        public string YarnComposition { get; set; }
        public int CountID { get; set; }
        public string YarnCount { get; set; }
        public int YarnQualityID { get; set; }
        public string YarnQuality { get; set; }
        public string YarnDyeingMethodID { get; set; }
        public string YarnDyeingMethod { get; set; }
        public string YarnColorID { get; set; }
        public string YarnColor { get; set; }
        public int ContaminationID { get; set; }
        public string Contamination { get; set; }






        public int YarnAttributeInstanceID { get; set; }
        public int SupplierID { get; set; }
        public int BrandID { get; set; }
        public int PackagingID { get; set; }
        public int ConesPerProcurementUnit { get; set; }
        public int UnitID { get; set; }
        public int Unit { get; set; }
        public int LocationID { get; set; }
        public int Loaction { get; set; }
        public int rate { get; set; }
        public int rateUnitID { get; set; }
        public int MovingAverage { get; set; }
        public int TransactionQty { get; set; }
        public int ProgramTypeID { get; set; }
        public int LotNo { get; set; }
        public int Status { get; set; }
        public int RateWRTBaseUnit { get; set; }
        public int SupplierName { get; set; }
        public int YarnKnittingContractID { get; set; }
        public int FabricGroup { get; set; }
        public int MasterShade { get; set; }
        public int AllocatedQty { get; set; }
        public int IssuedQtyBag { get; set; }
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int BagName { get; set; }
        public int IssuedQty { get; set; }
        public int IssuedAgainst { get; set; }
        public int IssuingUnitID { get; set; }
        public List<YKNCLotMasterDetailInfoRM> YKNCLotMasterDetailInfo { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<View_AttributeInstanceYarnInfo, YarnAttributeInfoRM>();
        }
    }
}
