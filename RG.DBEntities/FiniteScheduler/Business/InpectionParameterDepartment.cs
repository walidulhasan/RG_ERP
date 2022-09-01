using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class InpectionParameterDepartment
    {
        public int InspectionDepartmentId { get; set; }
        public int InspectionParameterId { get; set; }

        public virtual InpectionDepartment InspectionDepartment { get; set; }
        public virtual InspectionParameter InspectionParameter { get; set; }
    }
}
