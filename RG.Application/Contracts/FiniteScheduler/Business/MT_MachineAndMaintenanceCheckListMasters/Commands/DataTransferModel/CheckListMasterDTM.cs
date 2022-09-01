using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel
{
    public class CheckListMasterDTM:IMapFrom<MT_MachineAndMaintenanceCheckListMaster>
    {
        public CheckListMasterDTM()
        {
            MachineAndMaintenanceCheckListDetails = new List<CheckListDetailsDTM>();
        }
        public int MasterID { get; set; }
        public int MachineID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime CheckDate { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string MechanicalTaskCompletedBy { get; set; }        
        public string MechanicalTaskSupervisor { get; set; }        
        //public DateTime NextPreventativeDate { get; set; }
        public string ElectricalWorkerComments { get; set; }
        public string ElectricalTaskCompletedBy { get; set; }        
        public string ElectricalTaskSupervisor { get; set; }
        public List<CheckListDetailsDTM> MachineAndMaintenanceCheckListDetails { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CheckListMasterDTM, MT_MachineAndMaintenanceCheckListMaster>();
        }
    }
}
