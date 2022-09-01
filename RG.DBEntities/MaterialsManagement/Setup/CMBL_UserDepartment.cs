using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_UserDepartment
    {
        [Key]
       public int UserID { get; set; }
       public int CostCenterID  {get;set;}
       public int ActivityID    {get;set;}
       public string UserName      {get;set;}
       public int? CompanyID     {get;set;}
       public int? StoreID       {get;set;}

    }
}
