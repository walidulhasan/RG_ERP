using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceItem_Setups.Commands.DataTransferModel
{
  public  class MT_MaintenanceItem_SetupDTM:IMapFrom<MT_MaintenanceItem_Setup>
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int ItemCategoryID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MT_MaintenanceItem_SetupDTM, MT_MaintenanceItem_Setup>().ReverseMap();
        }
    }
}
