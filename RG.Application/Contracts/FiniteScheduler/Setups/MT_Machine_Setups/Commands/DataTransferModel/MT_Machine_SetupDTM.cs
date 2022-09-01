using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_Machine_Setups.Commands.DataTransferModel
{
  public  class MT_Machine_SetupDTM: IMapFrom< MT_Machine_Setup>
    {
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public string MachineCode { get; set; }
        public int LocationID { get; set; }
        public int? DepartmentID { get; set; }
        public int MachineGroupID { get; set; }
        //public DateTime? CheckedDate { get; set; }
        //public DateTime? NextCheckDate { get; set; }
        public int? MinMaintainceDurationDays { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MT_Machine_SetupDTM, MT_Machine_Setup>().ReverseMap();
        }

    }
}
