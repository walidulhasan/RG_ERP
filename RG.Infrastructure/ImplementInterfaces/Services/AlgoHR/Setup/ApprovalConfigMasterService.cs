using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Setup
{
    public class ApprovalConfigMasterService : IApprovalConfigMasterService
    {
        private readonly IApprovalConfigMasterRepository _approvalConfigMasterRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly Ivw_ERP_EmpShortInfoRepository _vw_ERP_EmpShortInfoRepository;
        private readonly ITbl_CompanyRepository _tbl_CompanyRepository;
        private readonly ITbl_DivisionRepository _tbl_DivisionRepository;
        private readonly ITbl_DeptRepository _tbl_DeptRepository;
        private readonly ITbl_SectionRepository _tbl_SectionRepository;
        private readonly ITbl_DesignationRepository _tbl_DesignationRepository;
        private readonly IApprovalModulesService approvalModulesService;

        public ApprovalConfigMasterService(IApprovalConfigMasterRepository approvalConfigMasterRepository
            , ICurrentUserService currentUserService
            , Ivw_ERP_EmpShortInfoRepository vw_ERP_EmpShortInfoRepository, ITbl_CompanyRepository tbl_CompanyRepository
            , ITbl_DivisionRepository tbl_DivisionRepository, ITbl_DeptRepository tbl_DeptRepository
            , ITbl_SectionRepository tbl_SectionRepository, ITbl_DesignationRepository tbl_DesignationRepository
            , IApprovalModulesService _approvalModulesService)
        {
            _approvalConfigMasterRepository = approvalConfigMasterRepository;
            _currentUserService = currentUserService;
            _vw_ERP_EmpShortInfoRepository = vw_ERP_EmpShortInfoRepository;
            _tbl_CompanyRepository = tbl_CompanyRepository;
            _tbl_DivisionRepository = tbl_DivisionRepository;
            _tbl_DeptRepository = tbl_DeptRepository;
            _tbl_SectionRepository = tbl_SectionRepository;
            _tbl_DesignationRepository = tbl_DesignationRepository;
            approvalModulesService = _approvalModulesService;
        }



        public async Task<List<ApprovalConfigurationRM>> GetModuleWiseApprovalConfigDetail(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken)
        {
            List<ApprovalConfigurationRM> data = new();
            try
            {
                var configuration = await _approvalConfigMasterRepository.GetModuleWiseApprovalConfig(queryModel, cancellationToken);
                if (configuration != null)
                {
                    var configDetail = configuration.ApprovalConfigDetail;
                    var companies = _tbl_CompanyRepository.GetAll()
                       .Select(x => new
                       {
                           x.Cmp_Name,
                           x.EmbroCompanyID
                       }).Distinct().ToList();
                    var divisions = await _tbl_DivisionRepository.GetAllAsync(cancellationToken);
                    var departments = await _tbl_DeptRepository.GetAllAsync(cancellationToken);
                    var sections = await _tbl_SectionRepository.GetAllAsync(cancellationToken);
                    var designations = await _tbl_DesignationRepository.GetAllAsync(cancellationToken);
                    var allEmp = await _vw_ERP_EmpShortInfoRepository.GetAllAsync(cancellationToken);

                    data = (from cd in configDetail
                            join c in companies on cd.ApproverCompanyID equals c.EmbroCompanyID
                            join ld in divisions on cd.ApproverOfficeDivisionID equals ld.Division_ID into igDiv
                            from d in igDiv.DefaultIfEmpty()
                            join ldp in departments on cd.ApproverDepartmentID equals ldp.Dept_ID into igDep
                            from dp in igDep.DefaultIfEmpty()
                            join ldg in designations on cd.ApproverJobTitleID equals ldg.Designation_Id into igDesi
                            from dg in igDesi.DefaultIfEmpty()
                            join s in sections on cd.ApproverSectionID equals s.Section_Id into ljsec
                            from ljs in ljsec.DefaultIfEmpty()
                            join e in allEmp on cd.ApproverEmployeeID equals (int)e.EmployeeID into ljemp
                            from lje in ljemp.DefaultIfEmpty()

                            select new ApprovalConfigurationRM
                            {
                                ConfigMasterID = cd.ConfigMasterID,
                                ModuleName = queryModel.ModuleName,
                                ConfigDetailID = cd.ConfigDetailID,
                                ApprovalLevel = cd.ApprovalLevel.Value,
                                ApproverCompanyID = c.EmbroCompanyID,
                                ApproverCompany = c.Cmp_Name,
                                ApproverOfficeDivisionID = d == null ? 0 : d.Division_ID,
                                ApproverOfficeDivision = d==null? "Please Assign" : d.Division_Name,
                                ApproverDepartmentID =dp==null?0: dp.Dept_ID,
                                ApproverDepartment =dp==null? "Please Assign" : dp.Dept_Name,
                                ApproverSectionID = ljs == null ? 0 : ljs.Section_Id,
                                ApproverSection = ljs == null ? "Please Assign" : ljs.Section_Name,
                                ApproverJobTitleID = dg==null?0:dg.Designation_Id,
                                ApproverJobTitle =dg==null?"Please Assign": dg.Designation_Name,
                                ApproverEmployeeID = lje == null ? 0 : (int)lje.EmployeeID,
                                ApproverEmployee = lje == null ? "Please Assign" : $"{lje.EmployeeCode}-{lje.EmployeeName.Trim()}",
                            }).OrderBy(x => x.ApprovalLevel).ToList();
                }


            }
            catch (Exception e)
            {
                throw;
            }

            return data;
        }

        public async Task<List<UserApprovalPowerRM>> GetUserApprovalPower(int designationID, int employeeID, CancellationToken cancellationToken)
        {
            return await _approvalConfigMasterRepository.GetUserApprovalPower(designationID, employeeID, cancellationToken);
        }

        public async Task<RResult> RemoveApprovalConfigMasterByDetail(int masterID, int detailID)
        {
            return await _approvalConfigMasterRepository.RemoveApprovalConfigMasterByDetail(masterID, detailID, _currentUserService.UserID);
        }

        public async Task<RResult> SaveApprovalConfigMaster(CreateApprovalConfigMasterDTM model)
        {
            var detailEntity = new List<ApprovalConfigDetail>();
            model.ApprovalConfigDetail.ForEach(x => detailEntity.Add(new ApprovalConfigDetail()
            {
                ConfigMasterID = x.ConfigMasterID,//model.ConfigMasterID > 0 ? model.ConfigMasterID : 0,
                ConfigDetailID = x.ConfigDetailID,
                ApproverCompanyID = x.ApproverCompanyID,
                ApproverOfficeDivisionID = x.ApproverOfficeDivisionID,
                ApproverDepartmentID = x.ApproverDepartmentID,
                ApproverSectionID = x.ApproverSectionID,
                ApproverJobTitleID = x.ApproverJobTitleID,
                ApproverEmployeeID = x.ApproverEmployeeID,
                ApprovalLevel = x.ApprovalLevel

            }));
            if (model.ConfigMasterID > 0)
            {
                return await _approvalConfigMasterRepository.SaveApprovalConfigDetail(detailEntity);
            }
            else
            {

                var entity = new ApprovalConfigMaster()
                {
                    ModuleName = model.ModuleName,
                    ConfigCompanyID = model.ConfigCompanyID,
                    ConfigOfficeDivisionID = model.ConfigOfficeDivisionID,
                    ConfigDepartmentID = model.ConfigDepartmentID,
                    ConfigSectionID = model.ConfigSectionID,
                    ConfigJobTitleID = model.ConfigJobTitleID,
                    ApprovalConfigDetail = detailEntity

                };
                return await _approvalConfigMasterRepository.SaveApprovalConfigMaster(entity);
            }
        }
        public async Task<ApprovalConfigMaster> GetEmployeeModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default)
        {
            try
            {
                var moduleInfo = await approvalModulesService.GetApprovalModulesByName(queryModel.ModuleName);
                if (moduleInfo.IsMasterConfigNeeded)
                {
                    return await MasterDependentApprovalConfig(queryModel, cancellationToken);
                }
                else
                {
                    return await MasterIndependentApprovalConfig(queryModel, cancellationToken);
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        private async Task<ApprovalConfigMaster> MasterIndependentApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken)
        {
            queryModel.ConfigCompanyID = null;
            queryModel.ConfigOfficeDivisionID = null;
            queryModel.ConfigDepartmentID = null;
            queryModel.ConfigSectionID = null;
            queryModel.ConfigJobTitleID = null;

            var configList = await _approvalConfigMasterRepository.GetEmployeeModuleWiseApprovalConfig(queryModel, cancellationToken);
            return configList.FirstOrDefault();
        }

        private async Task<ApprovalConfigMaster> MasterDependentApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken)
        {
            var configList = await _approvalConfigMasterRepository.GetEmployeeModuleWiseApprovalConfig(queryModel, cancellationToken);
            if (configList.Count > 0)
            {
                var dataDeptSecDesigMatching = configList.Where(x => x.ConfigDepartmentID == queryModel.ConfigDepartmentID && x.ConfigSectionID == queryModel.ConfigSectionID && x.ConfigJobTitleID == queryModel.ConfigJobTitleID).ToList();
                if (dataDeptSecDesigMatching.Count == 1)
                {
                    return dataDeptSecDesigMatching.First();
                }
                else
                {
                    var dataDeptSecMatching = configList.Where(x => x.ConfigDepartmentID == queryModel.ConfigDepartmentID && x.ConfigSectionID == queryModel.ConfigSectionID && x.ConfigJobTitleID == null).ToList();
                    if (dataDeptSecMatching.Count == 1)
                    {
                        return dataDeptSecMatching.First();
                    }
                    else
                    {
                        var dataDeptDesigMatching = configList.Where(x => x.ConfigDepartmentID == queryModel.ConfigDepartmentID && x.ConfigSectionID == null && x.ConfigJobTitleID == queryModel.ConfigJobTitleID).ToList();
                        if (dataDeptDesigMatching.Count == 1)
                        {
                            return dataDeptDesigMatching.First();
                        }
                        else
                        {
                            var dataDeptMatching = configList.Where(x => x.ConfigDepartmentID == queryModel.ConfigDepartmentID && x.ConfigSectionID == null && x.ConfigJobTitleID == null).ToList();
                            if (dataDeptMatching.Count == 1)
                            {
                                return dataDeptMatching.First();
                            }
                            else
                            {
                                var dataDesigMatching = configList.Where(x => x.ConfigDepartmentID == null && x.ConfigSectionID == null && x.ConfigJobTitleID == queryModel.ConfigJobTitleID).ToList();
                                if (dataDesigMatching.Count == 1)
                                {
                                    return dataDesigMatching.First();
                                }
                                else
                                {
                                    return configList.Where(x => x.ConfigDepartmentID == null && x.ConfigSectionID == null && x.ConfigJobTitleID == null).ToList().FirstOrDefault();
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                return new ApprovalConfigMaster();
            }
        }

        public async Task<RResult> ReplaceApprover(UpdateReplaceApproverDTM replaceApprover, CancellationToken cancellationToken)
        {
            replaceApprover.LastModifiedBy = _currentUserService.UserID;
            return await _approvalConfigMasterRepository.ReplaceApprover(replaceApprover, cancellationToken);
        }
    }
}
