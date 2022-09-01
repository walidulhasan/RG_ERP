using Microsoft.EntityFrameworkCore;
using RG.DBEntities.AlgoHR;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using RG.DBEntities.AlgoHR.Setup;

namespace RG.Application.Interfaces.Repositories.AlgoHR
{
    public interface IAlgoHRDBContext
    {
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
        public DbSet<Tbl_EmpOutSideTask> Tbl_EmpOutSideTask { get; set; }
        #region View 
        public DbSet<vw_ERP_EmpShortInfo> vw_ERP_EmpShortInfo { get; set; }
        #endregion

    }
}
