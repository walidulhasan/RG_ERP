using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class InpectionDepartment
    {
        public InpectionDepartment()
        {
            InpectionParameterDepartment = new HashSet<InpectionParameterDepartment>();
        }

        public int InspectionDepartmentId { get; set; }
        public string InspectionDepartmentName { get; set; }

        public virtual ICollection<InpectionParameterDepartment> InpectionParameterDepartment { get; set; }
    }
}
