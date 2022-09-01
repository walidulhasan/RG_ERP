using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Constants;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Tbl_EmpLeavess.Query.RequestResponseModel;
using RG.Application.Enums;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeaveCancel;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class Tbl_EmpLeavesService : ITbl_EmpLeavesService
    {
        private readonly ITbl_EmpLeavesRepository tbl_EmpLeavesRepository;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        private readonly IApprovalConfigMasterService approvalConfigMasterService;
        private readonly Ivw_ERP_EmpShortInfoService _vw_ERP_EmpShortInfo;
        private readonly IApprovalNotificationRepository approvalNotificationRepository;

        private readonly ITbl_EmpLeaves_DeletedRepository _tbl_EmpLeaves_DeletedRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IApplicationDocumentsService _applicationDocumentsService;
        private readonly IApprovalNotificationService _approvalNotificationService;
        private readonly IEmployeeLeaveCancelService _employeeLeaveCancelService;
        private readonly ITbl_EmpAttendanceService _tbl_EmpAttendanceService;
        private readonly IEmployeeShortLeaveRepository _employeeShortLeaveRepository;

        public Tbl_EmpLeavesService(ITbl_EmpLeavesRepository _tbl_EmpLeavesRepository, IMapper _mapper, ICurrentUserService _currentUserService
            , IApprovalConfigMasterService _approvalConfigMasterService, Ivw_ERP_EmpShortInfoService vw_ERP_EmpShortInfo
            , IApprovalNotificationRepository _approvalNotificationRepository
            , ITbl_EmpLeaves_DeletedRepository tbl_EmpLeaves_DeletedRepository, IWebHostEnvironment hostingEnvironment
            , IApplicationDocumentsService applicationDocumentsService, IApprovalNotificationService approvalNotificationService, IEmployeeLeaveCancelService employeeLeaveCancelService, ITbl_EmpAttendanceService tbl_EmpAttendanceService
            , IEmployeeShortLeaveRepository employeeShortLeaveRepository)
        {
            tbl_EmpLeavesRepository = _tbl_EmpLeavesRepository;
            mapper = _mapper;
            currentUserService = _currentUserService;
            approvalConfigMasterService = _approvalConfigMasterService;
            _vw_ERP_EmpShortInfo = vw_ERP_EmpShortInfo;
            approvalNotificationRepository = _approvalNotificationRepository;
            _tbl_EmpLeaves_DeletedRepository = tbl_EmpLeaves_DeletedRepository;
            _hostingEnvironment = hostingEnvironment;
            _applicationDocumentsService = applicationDocumentsService;
            _approvalNotificationService = approvalNotificationService;
            _employeeLeaveCancelService = employeeLeaveCancelService;
            _tbl_EmpAttendanceService = tbl_EmpAttendanceService;
            _employeeShortLeaveRepository = employeeShortLeaveRepository;
        }

        public async Task<RResult> DeleteTbl_EmpLeaves(int leaveID, int leaveTypeID, bool saveChange = true)
        {
            RResult rResult = new();
            try
            {
                bool isShortLeave = false;
                if (leaveTypeID != 0)
                {
                    var entity = await tbl_EmpLeavesRepository.GetByIdAsync((long)leaveID);
                    await tbl_EmpLeavesRepository.DeleteAsync((long)leaveID, saveChange);

                    Tbl_EmpLeaves_Deleted deletedEntity = new()
                    {
                        LeaveApplicationID = (int)entity.ID,
                        Leave_Emp = entity.Leave_Emp,
                        Leave_EmpCD = entity.Leave_EmpCD,
                        Leave_ID = entity.Leave_ID,
                        Leave_Fiscal = entity.Leave_Fiscal,
                        Leave_From = entity.Leave_From,
                        Leave_To = entity.Leave_To,
                        Leave_Created = entity.Leave_Created,
                        Leave_Reason = entity.Leave_Reason,
                        Leave_User = entity.Leave_User,
                        Leave_Approved = entity.Leave_Approved,
                        Leave_Code = entity.Leave_Code,
                        Leave_Address = entity.Leave_Address
                    };
                    await _tbl_EmpLeaves_DeletedRepository.InsertAsync(deletedEntity, saveChange);
                }
                else
                {
                    isShortLeave = true;
                    var entity = await _employeeShortLeaveRepository.GetByIdAsync(leaveID);
                    entity.IsRemoved = true;
                    await _employeeShortLeaveRepository.UpdateAsync(entity, saveChange);
                }

                var notification = await approvalNotificationRepository.FindAsync(x => x.ApplicationID == leaveID && x.ModuleName == ApprovalModules.LeaveApplication && x.IsShortLeave == isShortLeave && x.IsActive == true && x.IsRemoved == false);
                notification.IsRemoved = true;
                await approvalNotificationRepository.UpdateAsync(notification, saveChange);
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
                return rResult;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<List<EmployeeAvailedLeavesRM>> GetEmployeeAvailedLeaves(int employeeID, string employeeCode, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            return await tbl_EmpLeavesRepository.GetEmployeeAvailedLeaves(employeeID, employeeCode, dateFrom, dateTo, cancellationToken);
        }

        public async Task<List<LeaveHistoryDetailRM>> GetEmployeeLeaveHistoryDetail(LeaveHistoryDetailQM queryModel, CancellationToken cancellationToken)
        {
            var data = await tbl_EmpLeavesRepository.GetEmployeeLeaveHistoryDetail(queryModel, cancellationToken);

            return data;
        }

        public async Task<RResult> SaveTbl_EmpLeaves(EmpLeaveDTM model, bool saveChange = true)
        {
            RResult rResult = new();
            var empInfo = await _vw_ERP_EmpShortInfo.Get_ERP_EmpShortInfo(null, model.Leave_Emp);
            ModuleWiseApprovalConfigQM queryModel = new()
            {
                ModuleName = ApprovalModules.LeaveApplication,
                ConfigCompanyID = empInfo.EmbroCompanyID,
                ConfigOfficeDivisionID = empInfo.DivisionID,
                ConfigDepartmentID = empInfo.DepartmentID,
                ConfigSectionID = empInfo.SectionID,
                ConfigJobTitleID = empInfo.DesignationID
            };

            var approvalConfig = await approvalConfigMasterService.GetEmployeeModuleWiseApprovalConfig(queryModel);
            if (approvalConfig != null && approvalConfig.ApprovalConfigDetail.Count > 0)
            {

                var entity = mapper.Map<EmpLeaveDTM, Tbl_EmpLeaves>(model);
                entity.Leave_Created = DateTime.Now;
                entity.Leave_User = currentUserService.EmployeeCode;
                if (model.Leave_ID == 14 && model.Complimentary_LeaveDate != null)
                {
                    entity.Complimentary_LeaveDate = model.Complimentary_LeaveDate;
                }
                entity.EntrySource = EntrySource.Name190;
                rResult = await tbl_EmpLeavesRepository.SaveTbl_EmpLeaves(entity, saveChange);
                var applicationID = rResult.longId;
                var firstApprover = approvalConfig.ApprovalConfigDetail.ToList().Where(x => x.ApprovalLevel == 1).First();
                var notification = new ApprovalNotification
                {
                    ModuleName = ApprovalModules.LeaveApplication,
                    ApprovalMasterID = approvalConfig.ConfigMasterID,
                    ApprovalDetailID = firstApprover.ConfigDetailID,
                    //ApproverEmployeeID = firstApprover.ApproverEmployeeID,
                    ApplicationID = (int)applicationID,
                    CreatedDateOnly = DateTime.Now,
                };

                rResult = await approvalNotificationRepository.SaveApprovalNotification(notification);
                rResult.longId = applicationID;

                // upload Image
                if (model.UploadedImages != null)
                {
                    RResult result = await UploadImage(model.UploadedImages, applicationID, empInfo.EmployeeCode);
                }
            }
            else
            {
                rResult.result = 0;
                rResult.message = "No approval level found";
            }
            return rResult;
        }
        // upload Image
        private async Task<RResult> UploadImage(List<ImageUpload> uploadedImages, long applicationID, string employeeCode)
        {
            RResult rResult = new();
            Random rnd = new();
            var targetFolder = Path.Combine(FileUploadLocation.LeaveAttachments, DateTime.Now.Year.ToString(), DateTime.Now.ToString("MMMM"));
            string mainPath = Path.Combine(_hostingEnvironment.WebRootPath, targetFolder);
            mainPath = CreateDirectory(mainPath);

            //
            try
            {
                List<ApplicationDocuments> docs = new();
                foreach (var image in uploadedImages)
                {

                    byte[] bytes = Convert.FromBase64String(image.ImageBase64String.Replace("data:image/png;base64,", ""));
                    var fileName = $"{employeeCode}_{applicationID}_{rnd.Next(100, 999)}.png";
                    var filePath = Path.Combine(mainPath, fileName);
                    FileStream fs = new(filePath, FileMode.CreateNew);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    docs.Add(new ApplicationDocuments
                    {
                        ApplicationID = (int)applicationID
                        ,
                        DocumentTypeID = image.DocumentTypeID
                        ,
                        DocumentPath = Path.Combine(targetFolder, fileName)
                        ,
                        FileType = fileName.Split(".")[1]
                    });
                }
                //rResult.result = 1;
                //rResult.message = ReturnMessage.InsertMessage;
                rResult = await _applicationDocumentsService.SaveApplicationDocuments(docs);
                return rResult;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        private string CreateDirectory(string folderPath)
        {

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }

        public async Task<List<SearchedLeaveListRM>> SearchedLeaveList(int leaveID, string leaveStatus, DateTime dateFrom, DateTime dateTo, int companyID, int divisionID, int departmentID, CancellationToken cancellationToken)
        {
            var data = await tbl_EmpLeavesRepository.SearchedLeaveList(leaveID, leaveStatus, dateFrom, dateTo, companyID, divisionID, departmentID, cancellationToken);

            var finalData = data.Where(x => x.ApprovalLevel == 1).ToList();
            foreach (var item in finalData)
            {
                foreach (var approver in data.Where(x => x.LeaveApplicationID == item.LeaveApplicationID).OrderBy(x => x.ApprovalLevel))
                {
                    if (approver.ApprovalLevel == 1)
                    {
                        item.FirstApprover = $"{approver.ApproverEmployeeName}({approver.ApproverEmployeeCode})";
                        item.FirstApproverIsChecked = approver.IsChecked;
                    }
                    else if (approver.ApprovalLevel == 2)
                    {
                        item.SecondApprover = $"{approver.ApproverEmployeeName}({approver.ApproverEmployeeCode})";
                        item.SecondApproverIsChecked = approver.IsChecked;
                    }
                    else if (approver.ApprovalLevel == 3)
                    {
                        item.ThirdApprover = $"{approver.ApproverEmployeeName}({approver.ApproverEmployeeCode})";
                        item.ThirdApproverIsChecked = approver.IsChecked;
                    }
                    else if (approver.ApprovalLevel == 4)
                    {
                        item.FourthApprover = $"{approver.ApproverEmployeeName}({approver.ApproverEmployeeCode})";
                        item.FourthApproverIsChecked = approver.IsChecked;
                    }
                }

            }

            return finalData;

        }

        public async Task<RResult> AdjustTbl_EmpLeaves(int leaveID, DateTime AdjustedDateFrom, DateTime AdjustedDateTo, bool saveChange = true)
        {
            RResult rResult = new();
            var entity = await tbl_EmpLeavesRepository.GetByIdAsync((long)leaveID);
            entity.IsAdjusted = true;
            entity.OriginalLeave_From = entity.Leave_From;
            entity.OriginalLeave_To = entity.Leave_To;
            entity.Leave_From = AdjustedDateFrom;
            entity.Leave_To = AdjustedDateTo;
            entity.Adjusted_User = currentUserService.EmployeeCode;
            entity.AdjustedDate = DateTime.Now;
            await tbl_EmpLeavesRepository.UpdateAsync(entity, saveChange);
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }

        public async Task<Vw_EmpLeaves> GetEmpLeaveInfo(int leaveApplicationID, CancellationToken cancellationToken)
        {
            return await tbl_EmpLeavesRepository.GetEmpLeaveInfo(leaveApplicationID, cancellationToken);
        }

        public async Task<RResult> EmpLeaveApprovedFalse(int id, string Commant, string status, bool saveChanges = true)
        {
            try
            {
                RResult result = new();
                var dbModel = await tbl_EmpLeavesRepository.GetByIdAsync((long)id);
                if (dbModel.ID > 0)
                {
                    if (dbModel.Leave_Approved == null || !dbModel.Leave_Approved.Value)
                    {
                        await _approvalNotificationService.ApprovalNotificationCancel(id, Commant, status, ApprovalModules.LeaveApplication, saveChanges);
                    }

                    if ((dbModel.Leave_Approved != null && dbModel.Leave_Approved.Value) || status == "Approved")
                    {
                        if (status == "Approved")
                        {
                            await _tbl_EmpAttendanceService.AttendanceStatusChange(dbModel.Leave_Emp.Value, dbModel.Leave_From.Value, dbModel.Leave_To.Value, (int)enum_AttendanceStatus.LeaveWithPay, saveChanges);
                        }
                        else
                        {
                            await _tbl_EmpAttendanceService.AttendanceStatusChange(dbModel.Leave_Emp.Value, dbModel.Leave_From.Value, dbModel.Leave_To.Value, (int)enum_AttendanceStatus.Present, saveChanges);
                        }
                    }
                    if (status == "Approved")
                    {
                        dbModel.Leave_Approved = true;
                    }
                    else
                    {
                        dbModel.Leave_Approved = false;
                    }
                    await tbl_EmpLeavesRepository.UpdateAsync(dbModel, true);
                    result.result = 1;
                    if (status == "Approved")
                    {
                        result.message = "Successfully Approved Leave Application";
                    }
                    else
                    {
                        result.message = "Successfully Cancel Leave Application";
                    }



                }
                else
                {
                    result.result = 0;
                    result.message = ReturnMessage.NoDataFound;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<RResult> ApplicationCancel(EmployeeLeaveCancelVM employeeLeaveCancelVM, CancellationToken cancellationToken)
        {
            var thisResult = await EmpLeaveApprovedFalse((int)employeeLeaveCancelVM.LeaveID, employeeLeaveCancelVM.Comment, employeeLeaveCancelVM.Status, false);
            if (employeeLeaveCancelVM.Status == "Cancel")
            {
                var result = await _employeeLeaveCancelService.Create(employeeLeaveCancelVM, true);
            }
            return thisResult;
        }

        public async Task<List<LeaveHistoryDetailInfoRM>> GetEmployeeLeaveHistoryDetailInfo(LeaveHistoryDetailInfoQM queryModel, CancellationToken cancellationToken)
        {
            var data = await tbl_EmpLeavesRepository.GetEmployeeLeaveHistoryDetailInfo(queryModel, cancellationToken);

            return data;
        }

        public async Task<RResult> ApprovedLeaveApplicationAdjust(EmployeeLeaveCancelVM leaveAdjust, CancellationToken cancellationToken)
        {
            var leaveEntity = await tbl_EmpLeavesRepository.GetByIdAsync(leaveAdjust.LeaveID);
            leaveEntity.AdjustedDate = leaveEntity.Leave_To;
            leaveEntity.Leave_To = leaveAdjust.AdjustedDateTo;
            leaveEntity.Leave_Reason = leaveEntity.Leave_Reason==null? leaveAdjust.Comment:$"{leaveEntity.Leave_Reason} #Adj: {leaveAdjust.Comment}";
            var result = await tbl_EmpLeavesRepository.UpdateTbl_EmpLeaves(leaveEntity, true);
            
            if (result.result == 1)
            {
                result = await _tbl_EmpAttendanceService.GenerateAttendance(leaveEntity.Leave_To.Value, leaveEntity.AdjustedDate.Value, 0, 0, 0, 0, leaveEntity.Leave_EmpCD.Trim(), 0);
            }
            return result;
        }

        //public async Task<RResult> LeaveApplicationApproved(EmployeeLeaveCancelVM employeeLeaveCancelVM, CancellationToken cancellationToken)
        //{
        //    var thisResult = await ApplicationCancel(employeeLeaveCancelVM,cancellationToken);
        //    return thisResult;
        //}
    }
}
