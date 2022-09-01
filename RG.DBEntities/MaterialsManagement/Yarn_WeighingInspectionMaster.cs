using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_WeighingInspectionMaster
    {
        public Yarn_WeighingInspectionMaster()
        {
           // YarnWeighingInspectionDetail = new HashSet<YarnWeighingInspectionDetail>();
        }
        [Key]
        public long YarnWeighInspID { get; set; }
        public long YarnTempRecID { get; set; }
        public long POID { get; set; }
        public long WeighingInspStatus { get; set; }
        public long? SampleUNit { get; set; }
        public decimal? TarePerUnit { get; set; }
        public decimal? TotalQty { get; set; }
        public decimal? StandardWeightPerUnit { get; set; }
        public decimal? AverageNetWeightPerUnit { get; set; }
        public decimal? AverageGrossWeightPerUnit { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string InspectionNo { get; set; }
        public string UserName { get; set; }
        public long? UserID { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }

       // public virtual ICollection<YarnWeighingInspectionDetail> YarnWeighingInspectionDetail { get; set; }
    }
}
