using AutoMapper;
using RG.Application.Common.Mappings;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries.RequestResponseModel
{
    public class IC_UserDepartmentSetupQM : IMapFrom<IC_UserDepartmentSetupDTM>
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IC_UserDepartmentSetupQM, IC_UserDepartmentSetupDTM>();
        }
    }
}
