using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.AlgoHR.Business.Employee
{
    public class DetailInfoVM
    {
        [Display(Name ="Search Code")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Code")]
        public string Emp_Cd { get; set; }
        [Display(Name = "Old Code")]
        public string Emp_oldNo { get; set; }
        [Display(Name = "Name")]
        public string Emp_Name { get; set; }
        [Display(Name = "First Name")]
        public string Emp_Fname { get; set; }
        [Display(Name = "Middle Name")]
        public string Emp_Mname { get; set; }
        [Display(Name = "Last Name")]
        public string Emp_Lname { get; set; }
        [Display(Name = "Appointment Date")]
        public string Emp_Appointment { get; set; }
        [Display(Name = "Confirmation Date")]
        public string Emp_Confirmation { get; set; }
        [Display(Name = "Employee Type")]
        public int? emp_type { get; set; }
        [Display(Name = "Religion")]
        public Int16? Emp_Religion { get; set; }
        [Display(Name = "SSN(NID)")]
        public string Emp_SSN { get; set; }
        [Display(Name = "Father")]
        public string Emp_Father { get; set; }
        [Display(Name = "Mother")]
        public string Emp_MotherName { get; set; }
        [Display(Name = "Birth Date")]
        public string Emp_DOB { get; set; }
        //For Address
        [Display(Name = "Country")]
        public string Emp_Country1 { get; set; }
        [Display(Name ="State")]
        public string Emp_State1 { get; set; }
        [Display(Name = "City")]
        public string Emp_City1 { get; set; }
        [Display(Name = "Address")]
        public string Emp_Address1 { get; set; }
        [Display(Name = "Zip")]
        public string Emp_Zip1 { get; set; }


        [Display(Name = "Country")]
        public string Emp_Country2 { get; set; }
        [Display(Name = "State")]
        public string Emp_State2 { get; set; }
        [Display(Name = "City")]
        public string Emp_City2 { get; set; }
        [Display(Name = "Address")]
        public string Emp_Address2 { get; set; }
        [Display(Name = "Zip")]
        public string Emp_Zip2 { get; set; }
        [Display(Name ="Gender")]
        public string Emp_Gender { get; set; }



        public List<SelectListItem> DDLReligion { get; set; }
        public List<SelectListItem> DDLEmployeeType { get; set; }
        public List<SelectListItem> DDLEmployees { get; set; }
        public List<SelectListItem> DDLCountryList { get; set; }
        public List<SelectListItem> DDLGender { get; set; }

    }
}
