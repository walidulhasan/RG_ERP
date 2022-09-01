using RG.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeLeaveCancel
{
    public class EmployeeLeaveCancelVM:IMapFrom<DBEntities.AlgoHR.Business.EmployeeLeaveCancel>
    {
        public int LeaveCancelID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public long LeaveID { get; set; }
        public string Reason { get; set; }
        public string Recommendation { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime? AdjustedDateTo { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<EmployeeLeaveCancelVM, DBEntities.AlgoHR.Business.EmployeeLeaveCancel>();
        }
    }
}
