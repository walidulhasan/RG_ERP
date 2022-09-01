using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblBonus
    {
        public int Id { get; set; }
        public long EmpId { get; set; }
        public string EmpCd { get; set; }
        public string EmpOldNo { get; set; }
        public string EmpName { get; set; }
        public string EmpComp { get; set; }
        public int EmpCompid { get; set; }
        public string EmpDivision { get; set; }
        public int EmpDivisionid { get; set; }
        public string EmpDept { get; set; }
        public int EmpDeptid { get; set; }
        public string EmpSection { get; set; }
        public int EmpSectionid { get; set; }
        public string EmpLocation { get; set; }
        public int EmpLocationId { get; set; }
        public string EmpDesignation { get; set; }
        public int EmpDesignationid { get; set; }
        public DateTime EmpAppointment { get; set; }
        public double Absent { get; set; }
        public double EmpSalary { get; set; }
        public double EmpBonus { get; set; }
        public string EmpType { get; set; }
        public int? EmpTypeid { get; set; }
        public int? BonusType { get; set; }
        public int? BonusYear { get; set; }
    }
}
