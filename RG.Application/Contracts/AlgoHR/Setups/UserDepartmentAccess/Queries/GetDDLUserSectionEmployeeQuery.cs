using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Queries
{
    public class GetDDLUserSectionEmployeeQuery:IRequest<List<SelectListItem>>
    {
        public GetDDLUserSectionEmployeeQuery()
        {
            CompanyID = new List<int>();
            DivisionID = new List<int>();
            DepartmentID = new List<int>();
            SectionID = new List<int>();
            Designations = new List<int>();
            Locations = new List<int>();
            IsAll = false;

        }
        public int UserID { get; set; }
        public List<int> CompanyID { get; set; }
        public List<int> DivisionID { get; set; }
        public List<int> DepartmentID { get; set; }
        public List<int> SectionID { get; set; }
        public string Predict { get; set; } =null;
        public bool IsAll { get; set; }
        public List<int> Designations { get; set; }
        public List<int> Locations { get; set; }
        public int? EmployeeTypes { get; set; } = null;
        public string Gender { get; set; } = null;
        public bool? ActiveStatus { get; set; } = null;

    }

    public class GetDDLUserSectionEmployeeQueryHandler : IRequestHandler<GetDDLUserSectionEmployeeQuery, List<SelectListItem>>
    {
        private readonly IUserDepartmentAccessService _userDepartmentAccessService;

        public GetDDLUserSectionEmployeeQueryHandler(IUserDepartmentAccessService userDepartmentAccessService)
        {
            _userDepartmentAccessService = userDepartmentAccessService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLUserSectionEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _userDepartmentAccessService.DDLUserSectionEmployee(request.UserID,request.CompanyID,request.DivisionID,request.DepartmentID,request.SectionID
                ,request.Designations,request.Locations,request.EmployeeTypes,request.Gender,request.ActiveStatus
                ,request.Predict,request.IsAll,cancellationToken);
        }
    }
}
