using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.UserAuthentication
{
    public class ProjectMenus
    {
        //public ProjectMenus()
        //{
        //    UserWiseModule = new List<UserWiseModule>();
        //    RoleWiseModule = new List<RoleWiseModule>();
        //}
        [Key]
        public int ProjectMenuID { get; set; }

        public int ProjectID { get; set; }
        public string ProjectMenueCode { get; set; }
        public string LinkText { get; set; }
        public bool? IsExternalLink { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string MenuGroup { get; set; }
        public string ModuleSubCode { get; set; }
        public string ActionName { get; set; }
        public int? ParentModuleID { get; set; }
        public int? CompanyID { get; set; }
        public bool? IsMenuItem { get; set; }
        public int? DisplayOrder { get; set; }
        public string LinkTextUn { get; set; }
        public string UserType { get; set; }
        public string ModuleCode { get; set; }
        public string MenuSymbol { get; set; }
        public int? MenuLevel { get; set; }

        [Column(Order = 95)]
        public bool? IsActive { get; set; }

        [Column(Order = 96)]
        public bool? IsRemoved { get; set; }

        [Column(Order = 97)]
        public DateTime? CreatedDate { get; set; }

        [Column(Order = 98)]
        public int? CreatedBy { get; set; }

        [Column(Order = 99)]
        public DateTime? LastModifiedDate { get; set; }

        [Column(Order = 100)]
        public int? LastModifiedBy { get; set; }
    }

    //public List<UserWiseModule> UserWiseModule { get; set; }
    //public List<RoleWiseModule> RoleWiseModule { get; set; }
}