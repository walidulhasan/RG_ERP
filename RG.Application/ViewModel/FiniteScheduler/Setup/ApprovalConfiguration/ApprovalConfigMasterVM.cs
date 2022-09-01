using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.ApprovalConfiguration
{
    public class ApprovalConfigMasterVM
    {
        public ApprovalConfigMasterVM()
        {
            ApprovalConfigDetail = new List<ApprovalConfigDetailVM>();
        }
        public int ConfigMasterID { get; set; }
        [Display(Name = "Module Name")]
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        [Display(Name = "Applicant Company")]
        public int? ConfigCompanyID { get; set; }
        public int? ConfigOfficeID { get; set; }
        [Display(Name = "Applicant Division")]
        public int? ConfigOfficeDivisionID { get; set; }
        [Display(Name = "Applicant Department")]
        public int? ConfigDepartmentID { get; set; }
        [Display(Name = "Applicant Section")]
        public int? ConfigSectionID { get; set; }
        [Display(Name = "Applicant Designation")]
        public int? ConfigJobTitleID { get; set; }

        #region approver
        [Display(Name = "Approver Company")]
        public int? ApproverCompanyID { get; set; }
        [Display(Name = "Approver Office")]
        public int? ApproverOfficeID { get; set; }
        [Display(Name = "Approver Division")]
        public int? ApproverOfficeDivisionID { get; set; }
        [Display(Name = "Approver Department")]
        public int? ApproverDepartmentID { get; set; }
        [Display(Name = "Approver Section")]
        public int? ApproverSectionID { get; set; }
        [Display(Name = "Approver Designation")]
        public int ApproverJobTitleID { get; set; }
        [Display(Name = "Approver Employee")]
        public int? ApproverEmployeeID { get; set; }
        [Display(Name = "Approval Level")]
        public int? ApprovalLevel { get; set; }
        #endregion approver
        public List<ApprovalConfigDetailVM> ApprovalConfigDetail { get; set; }
        public List<SelectListItem> DDLCompanyList { get; set; }
        public List<SelectListItem> DDLOfficeDivisionList { get; set; }
        public List<SelectListItem> DDLDepartmentList { get; set; }
        public List<SelectListItem> DDLSectionList { get; set; }
        public List<SelectListItem> DDLJobTitleList { get; set; }
        public List<SelectListItem> DDLEmployeeList { get; set; }
        public List<DropDownItem> DDLApprovalModulesList { get; set; }
        public List<SelectListItem> DDLApprovalLevelList { get; set; }


        #region Modal Properties
        //From
        public int FromEmployeeID { get; set; }
        [Display(Name = "Code")]
        public string FromEmployeeCode { get; set; }
        [Display(Name = "Name")]
        public string FromEmployeeName { get; set; }
        public int FromCompanyID { get; set; }
        [Display(Name = "Company")]
        public string FromCompanyName { get; set; }
        public int FromDivisionID { get; set; }
        [Display(Name = "Division")]
        public string FromDivisionName { get; set; }
        public int FromDepartmentID { get; set; }
        [Display(Name = "Department")]
        public string FromDepartmentName { get; set; }
        public int FromSectionID { get; set; }
        [Display(Name = "Section")]
        public string FromSectionName { get; set; }
        public int FromDesignationID { get; set; }
        [Display(Name = "Designation")]
        public string FromDesignation { get; set; }
        [Display(Name = "Appointment Date")]
        public string FromAppointmentDate { get; set; }
        public List<SelectListItem> FromDDLEmployee { get; set; }

        //To
        public int ToEmployeeID { get; set; }
        [Display(Name = "Code")]
        public string ToEmployeeCode { get; set; }
        [Display(Name = "Name")]
        public string ToEmployeeName { get; set; }
        public int ToCompanyID { get; set; }
        [Display(Name = "Company")]
        public string ToCompanyName { get; set; }
        public int ToDivisionID { get; set; }
        [Display(Name = "Division")]
        public string ToDivisionName { get; set; }
        public int ToDepartmentID { get; set; }
        [Display(Name = "Department")]
        public string ToDepartmentName { get; set; }
        public int ToSectionID { get; set; }
        [Display(Name = "Section")]
        public string ToSectionName { get; set; }
        public int ToDesignationID { get; set; }
        [Display(Name = "Designation")]
        public string ToDesignation { get; set; }
        [Display(Name = "Appointment Date")]
        public string ToAppointmentDate { get; set; }
        public List<SelectListItem> ToDDLEmployee { get; set; }

        #endregion

    }
}
