using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Leavess.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class Tbl_LeavesService : ITbl_LeavesService
    {
        private readonly ITbl_LeavesRepository _tbl_LeavesRepository;
        private readonly Ivw_ERP_EmpShortInfoService _vw_ERP_EmpShortInfoService;
        private readonly IMapper _mapper;
        private readonly ITbl_EmpLeavesService tbl_EmpLeavesService;
        private readonly ITbl_LeaveOpeningBalanceService tbl_LeaveOpeningBalanceService;
        private readonly IEmployeeShortLeaveService _employeeShortLeaveService;

        public Tbl_LeavesService(ITbl_LeavesRepository tbl_LeavesRepository, Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfoService
            , IMapper mapper, ITbl_EmpLeavesService _tbl_EmpLeavesService, ITbl_LeaveOpeningBalanceService _tbl_LeaveOpeningBalanceService
            , IEmployeeShortLeaveService employeeShortLeaveService)
        {
            _tbl_LeavesRepository = tbl_LeavesRepository;
            _vw_ERP_EmpShortInfoService = vw_ERP_EmpShortInfoService;
            _mapper = mapper;
            tbl_EmpLeavesService = _tbl_EmpLeavesService;
            tbl_LeaveOpeningBalanceService = _tbl_LeaveOpeningBalanceService;
            _employeeShortLeaveService = employeeShortLeaveService;
        }

        public async Task<List<DropDownItem>> DDLCustomEmpLeaves(int employeeID, string employeeCode, CancellationToken cancellationToken)
        {

            if (employeeID == 0 && employeeCode != "")
            {
                var emp = await _vw_ERP_EmpShortInfoService.Get_ERP_EmpShortInfo(employeeCode, employeeID, cancellationToken);
                employeeID = (int)emp.EmployeeID;
            }
            else if (employeeID > 0 && employeeCode == "")
            {
                var emp = await _vw_ERP_EmpShortInfoService.Get_ERP_EmpShortInfo(employeeCode, employeeID, cancellationToken);
                employeeCode = emp.EmployeeCode;
            }

            var leaves = await GetEmployeeWiseLeaves(employeeID, cancellationToken);
            var dateFrom = new DateTime(DateTime.Now.Year, 1, 1);
            var dateTo = dateFrom.AddYears(1).AddDays(-1);

            var leaveAvailed = await tbl_EmpLeavesService.GetEmployeeAvailedLeaves(employeeID, employeeCode, dateFrom, dateTo, cancellationToken);
            
            var returnData = new List<DropDownItem>() { new DropDownItem { Text = "Please Select", Value = "" } };
            returnData.AddRange((from l in leaves
                                 join la in leaveAvailed on l.Leaves_ID equals la.LeaveID into lalj
                                 from lalj1 in lalj.DefaultIfEmpty()
                                 select new DropDownItem
                                 {
                                     Text = l.Leaves_Desc.Trim(),
                                     Value = l.Leaves_ID.ToString(),
                                     Custom1 = l.Leaves_Days.ToString(),
                                     Custom2=l.IsDocumentRequired.ToString(),
                                     Custom3=l.DocumentRequiredForMoreThanDays!=null?l.DocumentRequiredForMoreThanDays.ToString():"0",
                                     Custom4 = lalj1 == null ? "0" : lalj1.AvailedLeaveCount.ToString()
                                 }).ToList());


            var shortLeaveAvaield = await _employeeShortLeaveService.GetEmployeeAvailedLeaves(employeeID, employeeCode, dateFrom, dateTo, cancellationToken);

            returnData.Add(new DropDownItem { Text = "Short Leave", Value = "SL",Custom1="0",Custom2="",Custom3="0",Custom4= shortLeaveAvaield.Count>0? shortLeaveAvaield.First().AvailedLeaveCount.ToString():"0" });
            return returnData;
        }

        public async Task<List<SelectListItem>> DDLLeaves( CancellationToken cancellationToken)
        {
            return await _tbl_LeavesRepository.DDLLeaves(cancellationToken);
        }

        public async Task<List<SelectListItem>> GetDDLComplimentaryLeave(long employeeID, CancellationToken cancellationToken)
        {
            return await _tbl_LeavesRepository.GetDDLComplimentaryLeave(employeeID,cancellationToken);
        }

        public async Task<List<Tbl_LeavesRM>> GetEmployeeWiseLeaves(int employeeID, CancellationToken cancellationToken)
        {
            try
            {
                var leaves = new List<Tbl_LeavesRM>();
                var empLeaves = new List<Tbl_Leaves>();
                var empInfo = await _vw_ERP_EmpShortInfoService.Get_ERP_EmpShortInfo(null, employeeID);
                var dbLeaves = await _tbl_LeavesRepository.GetAllAsync();
                var empJobDuration = (DateTime.Now - Convert.ToDateTime(empInfo.Emp_Appointment)).Days;

                //if (empInfo.Gender == "Male")
                //{
                //    empLeaves.AddRange(dbLeaves.Where(x => (x.Leave_Gender == "B" || x.Leave_Gender == "M") && x.Leaves_Lapse == true).ToList());                   
                //}
                //else
                //{
                //    empLeaves.AddRange(dbLeaves.Where(x => (x.Leave_Gender == "B" || x.Leave_Gender == "F") && x.Leaves_Lapse == true).ToList());                   
                //}
                empLeaves.AddRange(dbLeaves.Where(x => x.Leave_Gender == "B" && x.Leave_Legend != "FL" && x.Leaves_Lapse == true).ToList());

                if (empJobDuration > 365)
                {
                    var leaveOpening = await tbl_LeaveOpeningBalanceService.GetYearWiseEmployeeLeaveOpeningBalance(empInfo.EmployeeCode, DateTime.Now.Year, cancellationToken);
                    //var totalYearDaysPassed = (DateTime.Now - new DateTime(DateTime.Now.Year, 1, 1)).TotalDays+1;
                    empLeaves.AddRange((from l in dbLeaves
                                        join lob in leaveOpening on l.Leaves_ID equals lob.LeaveID
                                        select new Tbl_Leaves
                                        {
                                            Leaves_ID = l.Leaves_ID,
                                            Leaves_Desc = l.Leaves_Desc,
                                            Leaves_Lapse = l.Leaves_Lapse,
                                            Leaves_Days = (short)lob.OpeningBalance,//+(l.LeaveDayIncrementDuration>0? Math.Ceiling(totalYearDaysPassed/l.LeaveDayIncrementDuration.Value):0)),
                                            Leave_Legend = l.Leave_Legend,
                                            Leave_Gender = l.Leave_Gender,
                                            MaxAvailDaysAtATime = l.MaxAvailDaysAtATime,
                                            IsDocumentRequired=l.IsDocumentRequired,
                                            DocumentRequiredForMoreThanDays=l.DocumentRequiredForMoreThanDays
                                        }).ToList());
                }


                leaves = _mapper.Map<List<Tbl_Leaves>, List<Tbl_LeavesRM>>(empLeaves);
                return leaves;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
