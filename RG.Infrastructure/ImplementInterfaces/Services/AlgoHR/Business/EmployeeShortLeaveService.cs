using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeShortLeave;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class EmployeeShortLeaveService : IEmployeeShortLeaveService
    {
        private readonly IEmployeeShortLeaveRepository _employeeShortLeaveRepository;
        private readonly IMapper _mapper;
        private readonly Ivw_ERP_EmpShortInfoService _vw_ERP_EmpShortInfo;
        private readonly IApprovalConfigMasterService _approvalConfigMasterService;
        private readonly IApprovalNotificationRepository _approvalNotificationRepository;

        public EmployeeShortLeaveService(IEmployeeShortLeaveRepository employeeShortLeaveRepository,IMapper mapper
            , Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfo, IApprovalConfigMasterService approvalConfigMasterService
            , IApprovalNotificationRepository approvalNotificationRepository)
        {
            _employeeShortLeaveRepository = employeeShortLeaveRepository;
            _mapper = mapper;
            _vw_ERP_EmpShortInfo = vw_ERP_EmpShortInfo;
            _approvalConfigMasterService = approvalConfigMasterService;
            _approvalNotificationRepository = approvalNotificationRepository;
        }
        public async Task<RResult> EmployeeShortLeaveCreate(ShortLeaveCreateVM shortLeave, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            RResult rResult = new();

            var shortLeaveMaxLimit =Convert.ToInt32(StaticConfigs.GetConfig("ShortLeaveMaxLimit"));

            var firstDateToCheck =new DateTime(shortLeave.LeaveDate.Year,shortLeave.LeaveDate.Month,1);
            var lastDateToCheck = firstDateToCheck.AddMonths(1).AddDays(-1);
     
            var appliedShortLeaveCount = (await _employeeShortLeaveRepository.FindAllAsync(x => x.IsActive == true && x.EmployeeID==shortLeave.EmployeeID
                                              && x.IsRemoved == false && (x.IsApproved == true || x.IsApproved==null) && x.LeaveDate.Date >= firstDateToCheck.Date
                                              && x.LeaveDate.Date <= lastDateToCheck)).ToList().Count;

            if (appliedShortLeaveCount< shortLeaveMaxLimit) {
                var empInfo = await _vw_ERP_EmpShortInfo.Get_ERP_EmpShortInfo(null, shortLeave.EmployeeID);
                ModuleWiseApprovalConfigQM queryModel = new()
                {
                    ModuleName = ApprovalModules.LeaveApplication,
                    ConfigCompanyID = empInfo.EmbroCompanyID,
                    ConfigOfficeDivisionID = empInfo.DivisionID,
                    ConfigDepartmentID = empInfo.DepartmentID,
                    ConfigSectionID = empInfo.SectionID,
                    ConfigJobTitleID = empInfo.DesignationID
                };

                var approvalConfig = await _approvalConfigMasterService.GetEmployeeModuleWiseApprovalConfig(queryModel);
                if (approvalConfig != null && approvalConfig.ApprovalConfigDetail.Count > 0)
                {

                    var entity = _mapper.Map<ShortLeaveCreateVM, EmployeeShortLeave>(shortLeave);

                    rResult = await _employeeShortLeaveRepository.EmployeeShortLeaveSave(entity, saveChanges);
                    var applicationID = rResult.longId;
                    var firstApprover = approvalConfig.ApprovalConfigDetail.ToList().Where(x => x.ApprovalLevel == 1).First();
                    var notification = new ApprovalNotification
                    {
                        ModuleName = ApprovalModules.LeaveApplication,
                        ApprovalMasterID = approvalConfig.ConfigMasterID,
                        ApprovalDetailID = firstApprover.ConfigDetailID,
                        IsShortLeave = true,
                        ApplicationID = (int)applicationID,
                        CreatedDateOnly = DateTime.Now,
                    };

                    rResult = await _approvalNotificationRepository.SaveApprovalNotification(notification);
                    rResult.longId = applicationID;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = "No approval level found";
                }
            }
            else
            {
                rResult.result = 0;
                rResult.message = $"You can't enjoy short leave more than {shortLeaveMaxLimit} day(s)";
            }
            return rResult;

        }

        public async Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            return await _employeeShortLeaveRepository.GetEmployeeAvailedLeaves(employeeID, employeeCode, dateFrom, dateTo, cancellationToken);
        }

        public async Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken)
        {
            return await _employeeShortLeaveRepository.GetEmployeeLeaveHistoryDetail(queryModel, cancellationToken);
        }
    }
}
