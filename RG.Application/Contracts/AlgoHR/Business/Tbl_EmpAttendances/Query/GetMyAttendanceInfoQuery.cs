using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpAttendances.Query
{
   public class GetMyAttendanceInfoQuery :IRequest<LoadResult>
    {
        public long EmployeeID { get; set; }
        public string AttendanceStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DataSourceLoadOptions loadOptions { get; set; }
    }
    public class GetMyAttendanceInfoQueryHandler : IRequestHandler<GetMyAttendanceInfoQuery, LoadResult>
    {
        private readonly ITbl_EmpAttendanceService _tbl_EmpAttendanceService;

        public GetMyAttendanceInfoQueryHandler(ITbl_EmpAttendanceService tbl_EmpAttendanceService)
        {
            _tbl_EmpAttendanceService = tbl_EmpAttendanceService;
        }
        public async Task<LoadResult> Handle(GetMyAttendanceInfoQuery request, CancellationToken cancellationToken)
        {
            var query = _tbl_EmpAttendanceService.GetMyAttendanceInfoData(request.EmployeeID, request.AttendanceStatus, request.DateFrom, request.DateTo);
            var aa = query.ToQueryString();
            request.loadOptions.PrimaryKey = new[] {"Serial" };
            
            request.loadOptions.PaginateViaPrimaryKey = true;
            var returnData = await DataSourceLoader.LoadAsync(query, request.loadOptions, cancellationToken);
            return returnData;
        }
 
    }

}

