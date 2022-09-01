using RG.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.AlgoHR.Business.EmployeeShortLeave
{
    public class ShortLeaveCreateVM:IMapFrom<DBEntities.AlgoHR.Business.EmployeeShortLeave>
    {
        public int ShortLeaveID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }        
        public bool Returnable { get; set; }
        public DateTime LeaveDate { get; set; }
        public string LeaveTimeFrom { get; set; }
        public string LeaveTimeTo { get; set; }
        public string? LeaveReason { get; set; }
        public string? LeaveAddress { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ShortLeaveCreateVM, DBEntities.AlgoHR.Business.EmployeeShortLeave>();
        }
    }
}
