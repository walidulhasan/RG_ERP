using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public partial class MM_MRPItem 
    {
        public MM_MRPItem()
        {
            MM_MRPGrossUnit = new HashSet<MM_MRPGrossUnit>();
            MM_MRPItemAttributeSet = new HashSet<MM_MRPItemAttributeSet>();
        }
        [Key]
        public int MRPItemCode { get; set; }
        public string MName { get; set; }
        public int? SKU { get; set; }
        public string PurchaseUnit { get; set; }
        public string IssueUnit { get; set; }
        public bool? IsMandatory { get; set; }
        public bool? IsOperation { get; set; }
        public long? LeadTimeFormulaID { get; set; }
        public long? WastageFormulaID { get; set; }
        public bool? IsDerivedFromCapturing { get; set; }
        public bool? IsRecursive { get; set; }
        public bool? IsRoutable { get; set; }
        public byte? ConversionLevel { get; set; }
        public string OperationName { get; set; }
        public bool? IsCRP { get; set; }
        public bool? IsIOP { get; set; }
        public long? LoadFormulaID { get; set; }
        public bool? IsLateralRouting { get; set; }
        public bool? IsFabric { get; set; }
        public int AgencyID { get; set; }

        public virtual ICollection<MM_MRPGrossUnit> MM_MRPGrossUnit { get; set; }
        public virtual ICollection<MM_MRPItemAttributeSet> MM_MRPItemAttributeSet { get; set; }
    }
}
