using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Company.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Depts.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Designations.Queries;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Divisions.Query;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Location.Queries;
using RG.Application.Contracts.AlgoHR.Setups.Tbl_Sections.Queries;
using RG.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.WEB.Areas.AlgoHR.Controllers
{
    [Area("AlgoHR")]
    [Route("AlgoHR/[controller]/[action]")]
    public class CommonDropDownController : BaseController
    {
        private readonly IDropdownService _dropdownService;

        public CommonDropDownController(IDropdownService dropdownService)
        {
            _dropdownService = dropdownService;
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLDivisionListByEmbroCompany(int embroCompanyID, List<int> exceptDivision = null, string Predict = null)
        {
            try
            {
                var parm = new GetDDLTbl_DivisionQuery();
                parm.EmbroCompanyID.Add(embroCompanyID);
                if (exceptDivision != null && exceptDivision.Count > 0)
                {
                    parm.ExceptDivision.AddRange(exceptDivision);
                }
                parm.Predict = Predict;

                var divisionList = _dropdownService.RenderDDL(await Mediator.Send(parm),true);
                return Json(divisionList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> GetDDLDivisionListByEmbroCompanys(List<int> embroCompanyID, List<int> exceptDivision = null, string Predict = null)
        {
            try
            {
                var divisionList = await Mediator.Send(new GetDDLTbl_DivisionQuery() { EmbroCompanyID = embroCompanyID, ExceptDivision = exceptDivision, Predict = Predict });
                return Json(divisionList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [AllowAnonymous]
        public async Task<JsonResult> GetDDLDeptList(int divisionID)
        {
            try
            {
                var query = new GetDDLTbl_DeptQuery();
                query.DivisionID.Add(divisionID);

                var deptList = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTbl_DeptQuery() { DivisionID = query.DivisionID }), true);
                return Json(deptList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLDeptListByDivisions(List<int> divisionID, string Predict = null)
        {
            try
            {
                var deptList = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTbl_DeptQuery() { DivisionID = divisionID, Predict = Predict }), true);
                return Json(deptList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [AllowAnonymous]
        public async Task<JsonResult> GetDDLSectionList(int deptID)
        {
            try
            {
                var query = new GetDDLTbl_SectionQuery();
                query.DepartmentID.Add(deptID);
                var sectionList = _dropdownService.RenderDDL(await Mediator.Send(query), true);
                return Json(sectionList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLSectionListByDepartments(List<int> deptID, string Predict = null)
        {
            try
            {
                var sectionList = _dropdownService.RenderDDL(await Mediator.Send(new GetDDLTbl_SectionQuery() { DepartmentID = deptID, Predict = Predict }), true);
                return Json(sectionList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLDesignationList(int officeDivisionID, int departmentID, int sectionID, bool defaultOption = false)
        {
            try
            {
                var designationList = await Mediator.Send(new GetDDLDesignationQuery() { OfficeDivisionID = officeDivisionID, DepartmentID = departmentID, SectionID = sectionID });
                if (defaultOption)
                    designationList = _dropdownService.RenderDDL(designationList, true);
                return Json(designationList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLDesignationFilterList(List<int> officeDivisionID, List<int> departmentID, List<int> sectionID, string Predict = null)
        {
            try
            {
                var designationList = await Mediator.Send(new GetDDLDesignationFilterQuery() { OfficeDivisionID = officeDivisionID, DepartmentID = departmentID, SectionID = sectionID,Predict=Predict });

                designationList = _dropdownService.RenderDDL(designationList, true);

                return Json(designationList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetLocationByCompanys(List<int> CompanyID, string Predict = null)
        {
            var query = new GetDDLTbl_LocationByCompanysQuery();
            query.Predict = Predict;
            query.CompanyList = CompanyID;
            var data = _dropdownService.RenderDDL(await Mediator.Send(query), true);
            return Json(data);
        }

        [AllowAnonymous]
        public async Task<JsonResult> GetDDLEmployeeList(int companyID, int officeDivisionID, int departmentID, int sectionID, int designationID, string Predict)
        {
            try
            {
                var employeeList = await Mediator.Send(new GetDDLHREmployeeQuery() { CompanyID = companyID, OfficeDivisionID = officeDivisionID, DepartmentID = departmentID, SectionID = sectionID, DesignationID = designationID, Predict = Predict });
                return Json(employeeList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLEmployeeListAdvanceFilter(List<int> companys, List<int> officeDivisions, List<int> departments,List<int> sections
                                       ,List<int> designations,List<int> locations,List<int> employeeTypes,string gender=null,int? activeStatus=1,string DPValue="ID", string Predict = null)
        {
            try
            {
                EmployeeDDLAdvanceFilterQM  filter = new EmployeeDDLAdvanceFilterQM();
                if(companys!=null && companys.Count > 0)
                {
                    filter.Companys = companys;
                }
                if (officeDivisions != null && officeDivisions.Count > 0)
                {
                    filter.Divisions = officeDivisions;
                }

                if (departments != null && departments.Count > 0)
                {
                    filter.Departments = departments;
                }

                if (sections != null && sections.Count > 0)
                {
                    filter.Sections = sections;
                }

                if (designations != null && designations.Count > 0)
                {
                    filter.Designation = designations;
                }

                if (locations != null && locations.Count > 0)
                {
                    filter.Locations = locations;
                }

                if (employeeTypes != null && employeeTypes.Count > 0)
                {
                    filter.EmployeeTypes = employeeTypes;
                }

                if(gender!=null && !string.IsNullOrWhiteSpace(gender))
                {
                    filter.Genders = gender;
                }

                int _activeStatus = activeStatus ?? 1;
                filter.ActiveStatus = _activeStatus == 1 ? true : false;

                filter.Predict = Predict;

                 
                var employeeList = await Mediator.Send(new GetDDLEmployeeByAdvanceFilterQuery() {Filter=filter,DPValue=DPValue  });
                return Json(employeeList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetDDLEmployee(string predict)
        {
            try
            {
                var employeeList = await Mediator.Send(new GetDDLEmployeeQuery { Predict = predict });
                return Json(employeeList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<JsonResult> GetDDLCompanyLookUp(int companyID)
        {
            var data = await Mediator.Send(new GetDDLCompanyLookUpQuery { CompanyID=companyID});
            return Json(data);
        }
        public async Task<JsonResult> GetDDLDivisionLookUp(List<int> embroCompanyID, List<int> exceptDivision, string predict)
        {
            var data = await Mediator.Send(new GetDDLDivisionLookUpQuery { EmbroCompanyID=embroCompanyID,ExceptDivision=exceptDivision,Predict=predict});
            return Json(data);
        }
        public async Task<JsonResult> GetDDLDepartmentLookUp(List<int> divisionID, string predict)
        {
            var data = await Mediator.Send(new GetDDLDepartmentLookupQuery {DivisionID= divisionID ,Predict= predict }); 
            return Json(data);
        }
        public async Task<JsonResult> GetDDLSectionLookUp(List<int> departmentID, string predict)
        {            
            var data = await Mediator.Send(new GetDDLSectionLookupQuery { DepartmentID=departmentID,Predict=predict});
            return Json(data);
        }        
        public async Task<JsonResult> GetDDLDesignationLookUp(List<int> companyID, List<int> divisionID, List<int> departmentID, List<int> sectionID, string predict)
        {
            var data = await Mediator.Send(new GetDDLDesignationLookupQuery { CompanyID = companyID, DivisionID = divisionID, DepartmentID = departmentID, SectionID = sectionID, Predict = predict });
            return Json(data);
        }        
        public async Task<JsonResult> GetDDLEmployeeLookUp(List<int> companyID, List<int> divisionID, List<int> departmentID, List<int> sectionID, List<int> designation, string predict)
        {
            var data = await Mediator.Send(new GetDDLHREmployeeLookupQuery {CompanyID=companyID,DivisionID=divisionID, DepartmentID = departmentID,SectionID=sectionID,Designation=designation, Predict = predict });
            return Json(data);
        }
        public async Task<JsonResult> GetDDLSectionDesignationLookup( List<int> sectionID, string predict)
        {
            var data = await Mediator.Send(new GetDDLSectionDesignationLookupQuery { SectionID = sectionID, Predict = predict });
            return Json(data);
        }
        
    }
}
