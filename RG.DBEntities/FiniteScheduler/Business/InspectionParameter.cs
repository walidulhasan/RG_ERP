using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class InspectionParameter
    {
        public InspectionParameter()
        {
            CuttingInspectionDetail = new HashSet<CuttingInspectionDetail>();
            InpectionParameterDepartment = new HashSet<InpectionParameterDepartment>();
        }

        public int InspectionParameterId { get; set; }
        public string InspectionParameterName { get; set; }

        public virtual ICollection<CuttingInspectionDetail> CuttingInspectionDetail { get; set; }
        public virtual ICollection<InpectionParameterDepartment> InpectionParameterDepartment { get; set; }
    }
}
