using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpOutSideTask.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
  public  class Tbl_EmpOutSideTaskService: ITbl_EmpOutSideTaskService
    {
        private readonly ITbl_EmpOutSideTaskRepository _tbl_EmpOutSideTaskRepository;
        private readonly IMapper mapper;
        private readonly Ivw_ERP_EmpShortInfoService _vw_ERP_EmpShortInfo;
        private readonly IApprovalConfigMasterService approvalConfigMasterService;
        private readonly IApprovalNotificationRepository approvalNotificationRepository;

        public Tbl_EmpOutSideTaskService(ITbl_EmpOutSideTaskRepository tbl_EmpOutSideTaskRepository,IMapper _mapper
            , Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfo, IApprovalConfigMasterService _approvalConfigMasterService
            , IApprovalNotificationRepository _approvalNotificationRepository)
        {
            _tbl_EmpOutSideTaskRepository = tbl_EmpOutSideTaskRepository;
            mapper = _mapper;
            _vw_ERP_EmpShortInfo = vw_ERP_EmpShortInfo;
            approvalConfigMasterService = _approvalConfigMasterService;
            approvalNotificationRepository = _approvalNotificationRepository;
        }

        public async Task<RResult> SaveTbl_EmpOutSideTask(OutsideDutyApplicationDTM model, bool saveChange = true)
        {
            RResult rResult = new();
            var entity = mapper.Map<OutsideDutyApplicationDTM, Tbl_EmpOutSideTask>(model);
            if (model.OutSideTaskID==0)
            {
                var empInfo = await _vw_ERP_EmpShortInfo.Get_ERP_EmpShortInfo(null, model.EmployeeID);
                ModuleWiseApprovalConfigQM queryModel = new()
                {
                    ModuleName = ApprovalModules.OutsideOfficeWork,
                    ConfigCompanyID = empInfo.EmbroCompanyID,
                    ConfigOfficeDivisionID = empInfo.DivisionID,
                    ConfigDepartmentID = empInfo.DepartmentID,
                    ConfigSectionID = empInfo.SectionID,
                    ConfigJobTitleID = empInfo.DesignationID
                };

                var approvalConfig = await approvalConfigMasterService.GetEmployeeModuleWiseApprovalConfig(queryModel);
                if (approvalConfig != null && approvalConfig.ApprovalConfigDetail.Count > 0)
                {
                    rResult= await _tbl_EmpOutSideTaskRepository.SaveTbl_EmpOutSideTask(entity, saveChange);

                    var applicationID = rResult.statusCode;
                    var firstApprover = approvalConfig.ApprovalConfigDetail.ToList().Where(x => x.ApprovalLevel == 1).First();
                    var notification = new ApprovalNotification
                    {
                        ModuleName = ApprovalModules.OutsideOfficeWork,
                        ApprovalMasterID = approvalConfig.ConfigMasterID,
                        ApprovalDetailID = firstApprover.ConfigDetailID,
                        //ApproverEmployeeID = firstApprover.ApproverEmployeeID,
                        ApplicationID = applicationID,
                        CreatedDateOnly = DateTime.Now,
                    };

                    rResult = await approvalNotificationRepository.SaveApprovalNotification(notification);
                    rResult.longId = applicationID;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = "No approval for outside duty found";
                }
                return rResult;
                
            }
            else
            {
                var dbEntity =await _tbl_EmpOutSideTaskRepository.GetByIdAsync(entity.OutSideTaskID);
                dbEntity.OutsideTaskDate = entity.OutsideTaskDate;
                dbEntity.TaskDurationType = entity.TaskDurationType;
                dbEntity.TimeFrom = entity.TimeFrom;
                dbEntity.TimeTo = entity.TimeTo;
                dbEntity.Reason = entity.Reason;
                dbEntity.TaskAddress = entity.TaskAddress;

                return await _tbl_EmpOutSideTaskRepository.UpdateTbl_EmpOutSideTask(entity, saveChange);

            }
        }
    }
}
