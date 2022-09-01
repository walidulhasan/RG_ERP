using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Constants
{
    public class SessionKey
    {
        public const string EMPLOYEE_ID = "LOGGEDIN_EMPLOYEEID";
        public const string User_EMPLOYEE_Code = "EMPLOYEE_Code";
        public const string EMPLOYEE_NAME = "LOGGEDIN_EMPLOYEE";//
        public const string IS_DAY_INITIATED = "IS_DAY_INITIATED";
        public const string USER_NAME = "USER_NAME";
        public const string USER_Designation = "USER_Designation";
        public const string USER_Designation_Name = "USER_Designation_Name";
        public const string USER_Department_Name = "USER_Department_Name";

        public const string PROCESS_TYPE = "PROCESS_TYPE";
        public const string PARENT_MODULES = "PARENT_MODULES";
        public const string USER_SECURITY_MODULES = "ROLE_MODULES";
        public const string All_Modules = "All_Modules";
        /// <summary>
        /// Logged In User Info Model
        /// </summary>
        public const string EMPLOYEE_INFO_Model = "LOGGEDIN_EMPLOYEE_INFO_Model";

        public const string IsSuperAdmin = "Session_IsSuperAdmin";
        public const string IsPageAdmin = "Session_IsSuperAdmin";

        public const string LASTDAYEND_DATE = "LASTDAYEND_DATE";
        public const string USER_ID = "Logged_USER_ID";
        public const string COMPANY_ID = "COMPANY_ID";
        public const string COUNTRY_ID = "COUNTRY_ID";
        public const string ROLE_ID = "ROLE_ID";
        public const string RoleName = "RoleName";

        public const string OfficeType_Id = "OfficeType_Id";
        public const string Office_Name = "Office_Name";
        public const string Office_Code = "Office_Code";
        public const string Current_Module_Keys = "Current_Module_Keys";

        public const string COMPANY_NAME = "COMPANY_NAME";
        public const string Company_NameOther = "Company_NameOther";

        public const string COMPANY_ADDRESS = "COMPANY_ADDRESS";
        public const string COMPANY_SHORTNAME = "COMPANY_SHORTNAME";
        public const string COMPANY_SHORTNAME_OTHER = "COMPANY_SHORTNAME_OTHER";

        public const string Approval_UserList = "Approval_UserList";
        public const string IS_APPLICATION_APPROVAL_USER = "IS_APPLICATION_APPROVAL_USER";
        public const string CompanyBusinessStartDT = "CompanyBusinessStartDT";

        public const string BusinessID = "Company_BusinessId";
        public const string BusinessName = "Company_BusinessName";
        public const string DomainID = "DomainID";

        public const string Finincial_Year = "Finincial_Year";
        // Remove this after Implementation Session_Company_BusinessName
        public const string Finincial_Year_Last = "Finincial_Year_Last";

        public const string Algo_UserID = "ALGO_USER_ID";
        public const string SourceEmployeeID = "Source_Employee_ID";


    }
}
