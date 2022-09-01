using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Interfaces.Repositories.AlgoHR;
using RG.DBEntities;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.DBEntities.AlgoHR.Setup;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.Persistence.AlgoHRDB
{
    public class AlgoHRDBContext : DbContext, IAlgoHRDBContext
    {
        private readonly ICurrentUserService _currentUserService;

        public AlgoHRDBContext(DbContextOptions<AlgoHRDBContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Tbl_Company> Tbl_Company { get; set; }
        public DbSet<Tbl_Division> Tbl_Division { get; set; }
        public DbSet<Tbl_Dept> Tbl_Dept { get; set; }
        public DbSet<Tbl_Section> Tbl_Section { get; set; }
        public DbSet<Tbl_Designation> Tbl_Designation { get; set; }
        public DbSet<Tbl_Emp> Tbl_Emp { get; set; }
        public DbSet<Tbl_EmpLeaves> Tbl_EmpLeaves { get; set; }
        public DbSet<Tbl_Leaves> Tbl_Leaves { get; set; }
        public DbSet<Tbl_EmpAttendance> Tbl_EmpAttendance { get; set; }
        public DbSet<LateAttendanceWarningLetterMaster> LateAttendanceWarningLetterMaster { get; set; }
        public DbSet<LateAttendanceWarningLetterDetail> LateAttendanceWarningLetterDetail { get; set; }
        public DbSet<Tbl_LeaveOpeningBalance> Tbl_LeaveOpeningBalance { get; set; }
        public DbSet<Tbl_EmpType> Tbl_EmpType { get; set; }
        public DbSet<Tbl_Location> Tbl_Location { get; set; }
        public DbSet<tbl_Shift> tbl_Shift { get; set; }
        public DbSet<ApprovalConfigMaster> ApprovalConfigMaster { get; set; }
        public DbSet<ApprovalConfigDetail> ApprovalConfigDetail { get; set; }
        public DbSet<ApprovalModules> ApprovalModules { get; set; }
        public DbSet<ApprovalNotification> ApprovalNotification { get; set; }
        public DbSet<Tbl_EmpShift> Tbl_EmpShift { get; set; }
        public DbSet<Tbl_AttendanceStatus> Tbl_AttendanceStatus { get; set; }
        public DbSet<UserDepartmentAccess> UserDepartmentAccess { get; set; }
        public DbSet<Tbl_Payroll_Master> Tbl_Payroll_Master { get; set; }
        public DbSet<Tbl_Holiday> Tbl_Holiday { get; set; }
        public DbSet<Tbl_Religion> Tbl_Religion { get; set; }
        public DbSet<Tbl_Country> Tbl_Country { get; set; }


        #region ajt

        public DbSet<Tbl_EmpOutSideTask> Tbl_EmpOutSideTask { get; set; }
        public DbSet<SystemNotice> SystemNotice { get; set; }
        public DbSet<SystemNoticeCustomCusting> SystemNoticeCustomCusting { get; set; }
        public DbSet<Tbl_EmpLeaves_Deleted> Tbl_DeletedEmpLeaves { get; set; }
        public DbSet<EmployeeShortLeave> EmployeeShortLeave { get; set; }
        public DbSet<UploadedDocumentType> UploadedDocumentType { get; set; }
        public DbSet<ApplicationDocuments> ApplicationDocuments { get; set; }
        public DbSet<EmployeeLeaveCancel> EmployeeLeaveCancel { get; set; }
        public DbSet<CompanyKPIParticulars> CompanyKPIParticulars { get; set; }
        public DbSet<KPIParticularValues> KPIParticularValues { get; set; }
        public DbSet<TrainingInfo> TrainingInfo { get; set; }
        public DbSet<TrainingDocuments> TrainingDocuments { get; set; }
        public DbSet<TrainingType> TrainingType { get; set; }
        public DbSet<CalenderEventDetails> CalenderEventDetails { get; set; }
        public DbSet<CalenderEventMaster> CalenderEventMaster { get; set; }
        public DbSet<CalenderEventFeedback> CalenderEventFeedback { get; set; }
        public DbSet<TrainingDocumentsComments> TrainingDocumentsComments { get; set; }

        #endregion
        #region rpt
        public DbSet<CompanyMonthlySalary> CompanyMonthlySalary { get; set; }
        public DbSet<SalaryAnalysisDivision> SalaryAnalysisDivision { get; set; }
        public DbSet<DivisionCostHeads> DivisionCostHeads { get; set; }
        public DbSet<DivisionSalaryCost> DivisionSalaryCost { get; set; }
        public DbSet<DivisionOtherCost> DivisionOtherCost { get; set; }
        public DbSet<MonthlyProductionCostAnalysis> MonthlyProductionCostAnalysis { get; set; }
        

        #endregion

        #region View 
        public DbSet<vw_ERP_EmpShortInfo> vw_ERP_EmpShortInfo { get; set; }
        public DbSet<Vw_EmpAttendance> Vw_EmpAttendance { get; set; }
        public DbSet<Vw_OutSideTask> Vw_OutSideTask { get; set; }
        public DbSet<Viw_ApprovalConfiguration> Viw_ApprovalConfiguration { get; set; }
        public DbSet<Vw_EmpLeaves> Vw_EmpLeaves { get; set; }
       

        
        #endregion
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<DefaultTableProperties>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsActive = true;
                        entry.Entity.IsRemoved = false;
                        entry.Entity.CreatedBy = _currentUserService.UserID;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserID;
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
