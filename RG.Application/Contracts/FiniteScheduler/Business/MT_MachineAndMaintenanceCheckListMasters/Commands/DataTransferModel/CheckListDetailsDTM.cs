using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.FiniteScheduler.Business;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Commands.DataTransferModel
{
    public class CheckListDetailsDTM : IMapFrom<MT_MachineAndMaintenanceCheckListDetails>
    {
        public int DetailID { get; set; }
        public int AssociationID { get; set; }
        public bool MechanicalChecked { get; set; }
        public string MechanicalComments { get; set; }
        public bool ElectricalChecked { get; set; }
        public string ElectricalComments { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CheckListDetailsDTM, MT_MachineAndMaintenanceCheckListDetails>();
        }
    }
}
