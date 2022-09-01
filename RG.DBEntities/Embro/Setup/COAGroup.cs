using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.Setup
{
    public class COAGroup : DefaultTableProperties
    {
        public int GroupID { get; set; }
        [ForeignKey("COAGroupCategory")]
        public int GroupCategoryID { get; set; }
        public string GroupCode { get; set; }
        public int GroupSerial { get; set; }
        public string GroupName { get; set; }
        public int ValueCondition { get; set; }
        public virtual COAGroupCategory COAGroupCategory { get; set; }
        public List<COAGroupIdentification> COAGroupIdentification { get; set; }
    }
}
