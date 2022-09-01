using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Commands.DataTransferModel
{
    public class CreateMT_MaintenanceSchedule_SetupDTM : IMapFrom<MT_MaintenanceSchedule_Setup>
    {
        public int ID { get; set; }
        public int MachineID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMT_MaintenanceSchedule_SetupDTM, MT_MaintenanceSchedule_Setup>();
        }
    }
}
