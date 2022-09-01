using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeave;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class LeaveHistoryDetailViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public LeaveHistoryDetailViewComponent(IMediator _mediator,IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(LeaveHistoryDetailQM queryModel)
        {
            var leaveHistory = await mediator.Send(new GetLeaveHistoryDetailQuery { QueryModel = new LeaveHistoryDetailQM { EmployeeID = queryModel.EmployeeID, LeaveTypeID = queryModel.LeaveTypeID
                                        , SearchYear = queryModel.SearchYear,LeaveStatus=queryModel.LeaveStatus,LeaveStatusIndependent=queryModel.LeaveStatusIndependent} });
            var data = mapper.Map<List<LeaveHistoryDetailRM>, List<LeaveHistoryDetailVCVM>>(leaveHistory);


            data.ForEach(x =>
            {
                x.ShowEmployeeCode = queryModel.ShowEmployeeCode; x.ShowEmployeeName = queryModel.ShowEmployeeName;
                x.ShowCompanyName = queryModel.ShowCompanyName; x.ShowDivisionName = queryModel.ShowDivisionName; x.ShowDepartmentName = queryModel.ShowDepartmentName;
                x.ShowSectionName = queryModel.ShowSectionName; x.ShowDesignationName = queryModel.ShowDesignationName; x.ShowAppointmentDate = queryModel.ShowAppointmentDate;
            });
            return View("LeaveHistoryDetailVC", data);
        }
    }
}
