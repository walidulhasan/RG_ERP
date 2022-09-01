using AutoMapper;
using RG.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpOutSideTask.Commands.DataTransferModel
{
    public class OutsideDutyApplicationDTM:IMapFrom<DBEntities.AlgoHR.Business.Tbl_EmpOutSideTask>
    {
        public int OutSideTaskID { get; set; }
        public long EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime OutsideTaskDate { get; set; }
        public string TaskDurationType { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        
        public string Reason { get; set; }
        public string TaskAddress { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OutsideDutyApplicationDTM, DBEntities.AlgoHR.Business.Tbl_EmpOutSideTask>();
        }
    }
}
