using AutoMapper;
using RG.Application.Common.Mappings;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel
{
    public class IC_UserDepartmentSetupDTM : IMapFrom<IC_UserDepartmentSetup>
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public int? AuthUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_UserDepartmentSetupDTM, IC_UserDepartmentSetup>();
        }
    }
}
