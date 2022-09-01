using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.ApprovalConfigMasters.Commands.Create;
using RG.Application.Contracts.FiniteScheduler.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.Application.Interfaces.Services.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.FiniteScheduler.Setup
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
        private readonly IApprovalConfigurationsService approvalConfigurationsService;

        public ApprovalConfigMasterService(IApprovalConfigMasterRepository approvalConfigMasterRepository
            , ICurrentUserService currentUserService
            , Ivw_ERP_EmpShortInfoRepository vw_ERP_EmpShortInfoRepository, ITbl_CompanyRepository tbl_CompanyRepository
            , ITbl_DivisionRepository tbl_DivisionRepository, ITbl_DeptRepository tbl_DeptRepository
            , ITbl_SectionRepository tbl_SectionRepository, ITbl_DesignationRepository tbl_DesignationRepository 
            , IApprovalConfigurationsService _approvalConfigurationsService)
        {
            _approvalConfigMasterRepository = approvalConfigMasterRepository;
            _currentUserService = currentUserService;
            _vw_ERP_EmpShortInfoRepository = vw_ERP_EmpShortInfoRepository;
            _tbl_CompanyRepository = tbl_CompanyRepository;
            _tbl_DivisionRepository = tbl_DivisionRepository;
            _tbl_DeptRepository = tbl_DeptRepository;
            _tbl_SectionRepository = tbl_SectionRepository;
            _tbl_DesignationRepository = tbl_DesignationRepository;
            approvalConfigurationsService = _approvalConfigurationsService;
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
                            join d in divisions on cd.ApproverOfficeDivisionID equals d.Division_ID
                            join dp in departments on cd.ApproverDepartmentID equals dp.Dept_ID
                            join dg in designations on cd.ApproverJobTitleID equals dg.Designation_Id
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
                                ApproverOfficeDivisionID = d.Division_ID,
                                ApproverOfficeDivision = d.Division_Name,
                                ApproverDepartmentID = dp.Dept_ID,
                                ApproverDepartment = dp.Dept_Name,
                                ApproverSectionID = ljs == null ? 0 : ljs.Section_Id,
                                ApproverSection = ljs == null ? "" : ljs.Section_Name,
                                ApproverJobTitleID = dg.Designation_Id,
                                ApproverJobTitle = dg.Designation_Name,
                                ApproverEmployeeID = lje == null ? 0 : (int)lje.EmployeeID,
                                ApproverEmployee = lje == null ? "" : $"{lje.EmployeeCode}-{lje.EmployeeName.Trim()}",
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
                ConfigMasterID = model.ConfigMasterID > 0 ? model.ConfigMasterID : 0,
                ApproverCompanyID = x.ApproverCompanyID,
                ApproverOfficeDivisionID = x.ApproverOfficeDivisionID,
                ApproverDepartmentID = x.ApproverDepartmentID,
                ApproverSectionID = x.ApproverSectionID,
                ApproverJobTitleID = x.ApproverJobTitleID,
                ApproverEmployeeID = x.ApproverEmployeeID,
                ApprovalLevel = x.ApprovalLevel,

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
    }
}
