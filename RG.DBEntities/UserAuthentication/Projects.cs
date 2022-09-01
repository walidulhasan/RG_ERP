using RG.DBEntities;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.UserAuthentication
{
    public class Projects : DefaultTableProperties
    {
        [Key]
        public int ProjectID { get; set; }

        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public bool ProjectHasBusiness { get; set; }
    }
}