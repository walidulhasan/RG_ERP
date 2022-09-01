using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.MT_MachineAndMaintenanceItemAssociations.Commands.DataTransferModel
{
    public class AssociationDTM : IMapFrom<MT_MachineAndMaintenanceItemAssociation>
    {
        public int MachineID { get; set; }
        public int MaintenanceItemID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssociationDTM, MT_MachineAndMaintenanceItemAssociation>();
        }
    }
}
