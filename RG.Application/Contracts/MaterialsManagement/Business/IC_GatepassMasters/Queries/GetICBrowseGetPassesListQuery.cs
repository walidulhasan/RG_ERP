using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.UserAuthGBS.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries
{
    public class GetICBrowseGetPassesListQuery : IRequest<LoadResult>
    {
        public GatepassQM GatepassRequiestModel { get; set; }
        public DataSourceLoadOptions LoadOptions { get; set; }


    }
    public class GetICBrowseGetPassesListQueryHandler : IRequestHandler<GetICBrowseGetPassesListQuery, LoadResult>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        private readonly IUserEmployeeService _userEmployeeService;

        public GetICBrowseGetPassesListQueryHandler(IIC_GatepassMasterService _iC_GatepassMasterService, IUserEmployeeService userEmployeeService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
            _userEmployeeService = userEmployeeService;
        }
        public async Task<LoadResult> Handle(GetICBrowseGetPassesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                request.LoadOptions.PrimaryKey = new[] { "GatePassID" };
                request.LoadOptions.PaginateViaPrimaryKey = true;
                var users = await _userEmployeeService.GetUserEmployee().ToListAsync();
                var dataQuery = iC_GatepassMasterService.GetICBrowseGetPassesList(request.GatepassRequiestModel);

                var da = dataQuery.ToQueryString();

                var finalData = await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);


                foreach (GatepassRM item in finalData.data)
                {
                    var user = users.Where(x => x.UserID == item.CA_UserID).FirstOrDefault();
                    if (user != null)
                    {
                        item.CreatedEmployee = user.EmployeeName;
                        item.CreatedEmployeeDept = user.DepartmentName;
                        item.CreatedEmployeeDesig = user.DesignationName;
                    }
                }
                return finalData;

            }
            catch (Exception e)
            {
                throw;
            }

        }


    }
}
